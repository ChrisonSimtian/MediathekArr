using MediathekArr.Models;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;

namespace MediathekArr.Services;

// TODO: Run this via Hangfire as a background job
public partial class DownloadService
{
    public DownloadService(IHttpClientFactory httpClientFactory, ILogger<DownloadService> logger)
    {
        HttpClientFactory = httpClientFactory;
        HttpClient = HttpClientFactory.CreateClient(Constants.HttpClientNameConstants.MediathekArrClient);

        Logger = logger;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) OSPlatform = OSPlatform.Linux;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) OSPlatform = OSPlatform.Windows;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD)) OSPlatform = OSPlatform.FreeBSD;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) OSPlatform = OSPlatform.OSX;

        // Set complete_dir based on the application's startup path
        var startupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        _completeDir = Path.Combine(startupPath, "downloads");
        _ffmpegPath = Path.Combine(startupPath, "ffmpeg", OSPlatform == OSPlatform.Windows ? "ffmpeg.exe" : "ffmpeg");

        // Ensure FFmpeg is available
        Task.Run(EnsureFfmpegExistsAsync).Wait();
    }
    public ILogger<DownloadService> Logger { get; }
    public OSPlatform OSPlatform { get; }
    public IHttpClientFactory HttpClientFactory { get; }

    private readonly ConcurrentQueue<SabnzbdQueueItem> _downloadQueue = new();
    private readonly List<SabnzbdHistoryItem> _downloadHistory = new();
    private HttpClient HttpClient { get; }
    private static readonly SemaphoreSlim _semaphore = new(2); // Limit concurrent downloads to 2
    private readonly string _completeDir;
    private readonly string _ffmpegPath;

    public IEnumerable<SabnzbdQueueItem> GetQueue() => [.. _downloadQueue];
    public IEnumerable<SabnzbdHistoryItem> GetHistory() => _downloadHistory;

    public SabnzbdQueueItem AddToQueue(string url, string fileName, string category)
    {
        var queueItem = new SabnzbdQueueItem
        {
            Status = SabnzbdDownloadStatus.Queued,
            Index = _downloadQueue.Count,
            Timeleft = "10:00:00",
            Size = "Unknown",
            Title = fileName,
            Category = category,
            Sizeleft = "Unknown",
            Percentage = "0"
        };

        _downloadQueue.Enqueue(queueItem);

        Task.Run(() => StartDownloadAsync(url, queueItem));

        return queueItem;
    }

    private async Task StartDownloadAsync(string url, SabnzbdQueueItem queueItem)
    {
        await _semaphore.WaitAsync();

        var stopwatch = Stopwatch.StartNew();

        try
        {
            Logger.LogInformation("Starting download for {Title} from URL: {URL}", queueItem.Title, url);
            await DownloadFileAsync(url, queueItem);

            if (queueItem.Status != SabnzbdDownloadStatus.Failed)
            {
                Logger.LogInformation("Download complete for {Title}. Starting conversion to MKV.", queueItem.Title);
                await ConvertMp4ToMkvAsync(queueItem, stopwatch);
            }
            else
            {
                Logger.LogWarning("Download failed for {Title}, skipping conversion.", queueItem.Title);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error occurred during the download or conversion of {Title}.", queueItem.Title);
        }
        finally
        {
            _semaphore.Release();
            _downloadQueue.TryDequeue(out _);
            stopwatch.Stop();
        }
    }

    private async Task DownloadFileAsync(string url, SabnzbdQueueItem queueItem)
    {
        try
        {
            var categoryDir = Path.Combine(_completeDir, queueItem.Category);
            Logger.LogInformation("Ensuring directory exists for category {Category} at path: {Path}", queueItem.Category, categoryDir);
            Directory.CreateDirectory(categoryDir);

            var fileExtension = Path.GetExtension(url) ?? ".mp4";
            var filePath = Path.Combine(categoryDir, queueItem.Title + fileExtension);

            Logger.LogInformation("Starting download of file to path: {Path} with extension {Extension}", filePath, fileExtension);
            queueItem.Status = SabnzbdDownloadStatus.Downloading;

            var response = await HttpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            var totalSize = response.Content.Headers.ContentLength ?? 0;

            queueItem.Size = (totalSize / (1024.0 * 1024.0)).ToString("F2");
            Logger.LogInformation("Total file size for {Title}: {Size} MB", queueItem.Title, queueItem.Size);

            using (var contentStream = await response.Content.ReadAsStreamAsync())
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var buffer = new byte[8192];
                var totalRead = 0L;
                int bytesRead;

                while ((bytesRead = await contentStream.ReadAsync(buffer.AsMemory(0, buffer.Length))) > 0)
                {
                    await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead));
                    totalRead += bytesRead;

                    // Update queue item progress
                    queueItem.Sizeleft = ((totalSize - totalRead) / (1024.0 * 1024.0)).ToString("F2");
                    queueItem.Percentage = (totalRead / (double)totalSize * 100).ToString("F0");

                    Logger.LogDebug("Download progress for {Title}: {Percentage}% - {SizeLeft} MB remaining", queueItem.Title, queueItem.Percentage, queueItem.Sizeleft);
                }
            }

            queueItem.Timeleft = "00:00:00";
            Logger.LogInformation("Download completed for {Title}. File saved to {Path}", queueItem.Title, filePath);
        }
        catch (Exception ex)
        {
            queueItem.Status = SabnzbdDownloadStatus.Failed;
            Logger.LogError(ex, "Download failed for {Title}. Adding to download history as failed.", queueItem.Title);

            _downloadHistory.Add(new SabnzbdHistoryItem
            {
                Title = queueItem.Title,
                NzbName = queueItem.Title,
                Category = queueItem.Category,
                Size = 0,
                DownloadTime = 0,
                Storage = null,
                Status = SabnzbdDownloadStatus.Failed,
                Id = queueItem.Id
            });
        }
    }
    public bool DeleteHistoryItem(string nzoId, bool delFiles)
    {
        var item = _downloadHistory.FirstOrDefault(h => h.Id == nzoId);

        if (item == null)
        {
            return false;
        }

        // Optionally delete the associated file
        if (delFiles && !string.IsNullOrEmpty(item.Storage) && File.Exists(item.Storage))
        {
            try
            {
                File.Delete(item.Storage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }

        // Remove the item from the history list
        _downloadHistory.Remove(item);
        return true;
    }

    private async Task ConvertMp4ToMkvAsync(SabnzbdQueueItem queueItem, Stopwatch stopwatch)
    {
        var categoryDir = Path.Combine(_completeDir, queueItem.Category);
        var mp4Path = Path.Combine(categoryDir, queueItem.Title + ".mp4");
        var mkvPath = Path.Combine(categoryDir, queueItem.Title + ".mkv");

        if (!File.Exists(mp4Path))
        {
            queueItem.Status = SabnzbdDownloadStatus.Failed;
            Logger.LogWarning("MP4 file not found for conversion. Path: {Mp4Path}. Marking as failed.", mp4Path);
            return;
        }

        queueItem.Status = SabnzbdDownloadStatus.Extracting;
        Logger.LogInformation("Starting conversion of {Title} from MP4 to MKV. MP4 Path: {Mp4Path}, MKV Path: {MkvPath}", queueItem.Title, mp4Path, mkvPath);

        var ffmpegArgs = $"-i \"{mp4Path}\" -map 0:v -map 0:a -c copy -metadata:s:v:0 language=ger -metadata:s:a:0 language=ger \"{mkvPath}\"";

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = _ffmpegPath,
                Arguments = ffmpegArgs,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        try
        {
            process.Start();
            Logger.LogInformation("FFmpeg process started for {Title} with arguments: {Arguments}", queueItem.Title, ffmpegArgs);

            var standardErrorTask = process.StandardError.ReadToEndAsync();

            await process.WaitForExitAsync();
            string ffmpegOutput = await standardErrorTask;

            if (process.ExitCode == 0)
            {
                queueItem.Status = SabnzbdDownloadStatus.Completed;
                Logger.LogInformation("Conversion completed successfully for {Title}. Output path: {MkvPath}", queueItem.Title, mkvPath);
            }
            else
            {
                queueItem.Status = SabnzbdDownloadStatus.Failed;
                Logger.LogError("FFmpeg conversion failed for {Title}. Exit code: {ExitCode}. Error output: {ErrorOutput}", queueItem.Title, process.ExitCode, ffmpegOutput);
            }

            File.Delete(mp4Path);

            double sizeInMB = 0;
            if (double.TryParse(queueItem.Size.Replace("GB", "").Replace("MB", "").Trim(), out double size))
            {
                sizeInMB = queueItem.Size.Contains("GB") ? size * 1024 : size;
            }

            var downloadFolderPathMapping = Environment.GetEnvironmentVariable("DOWNLOAD_FOLDER_PATH_MAPPING");

            var storagePath = !string.IsNullOrEmpty(downloadFolderPathMapping)
                ? Path.Combine(downloadFolderPathMapping, queueItem.Category, queueItem.Title + ".mkv")
                : mkvPath;

            // Move completed download to history
            var historyItem = new SabnzbdHistoryItem
            {
                Title = queueItem.Title,
                NzbName = queueItem.Title,
                Category = queueItem.Category,
                Size = (long)(sizeInMB * 1024 * 1024), // Convert MB to bytes
                DownloadTime = (int)stopwatch.Elapsed.TotalSeconds,
                Storage = storagePath,
                Status = queueItem.Status,
                Id = queueItem.Id
            };
            _downloadHistory.Add(historyItem);

            Logger.LogInformation("Download history updated for {Title}. Status: {Status}, Download Time: {DownloadTime}s, Size: {Size} bytes",
                queueItem.Title, queueItem.Status, historyItem.DownloadTime, historyItem.Size);
        }
        catch (Exception ex)
        {
            queueItem.Status = SabnzbdDownloadStatus.Failed;
            Logger.LogError(ex, "An error occurred during the conversion of {Title} from MP4 to MKV.", queueItem.Title);
        }
    }

    private async Task EnsureFfmpegExistsAsync()
    {
        if (!File.Exists(_ffmpegPath))
        {
            Logger.LogInformation("FFmpeg not found at path {FfmpegPath}. Starting download...", _ffmpegPath);

            // URLs for downloading FFmpeg based on OS
            string ffmpegDownloadUrl = OSPlatform == OSPlatform.Windows
                ? "https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip"
                : "https://johnvansickle.com/ffmpeg/releases/ffmpeg-release-amd64-static.tar.xz";

            var tempFilePath = Path.Combine(Path.GetTempPath(), OSPlatform == OSPlatform.Windows ? "ffmpeg.zip" : "ffmpeg.tar.xz");
            var ffmpegDir = Path.Combine(Path.GetDirectoryName(_ffmpegPath) ?? string.Empty);

            try
            {
                // Download FFmpeg file
                using (var response = await HttpClient.GetAsync(ffmpegDownloadUrl, HttpCompletionOption.ResponseHeadersRead))
                using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await response.Content.CopyToAsync(fileStream);
                    Logger.LogInformation("FFmpeg downloaded to temporary path {TempFilePath}", tempFilePath);
                }

                Directory.CreateDirectory(ffmpegDir);
                Logger.LogInformation("FFmpeg directory ensured at {FfmpegDir}", ffmpegDir);

                // Extract FFmpeg based on the OS
                if (OSPlatform == OSPlatform.Windows)
                {
                    ZipFile.ExtractToDirectory(tempFilePath, ffmpegDir);
                    Logger.LogInformation("FFmpeg extracted in Windows environment.");

                    // Move extracted ffmpeg.exe to the expected path
                    var extractedPath = Directory.GetFiles(ffmpegDir, "ffmpeg.exe", SearchOption.AllDirectories).FirstOrDefault();
                    if (extractedPath != null)
                    {
                        File.Move(extractedPath, _ffmpegPath, true);
                        Logger.LogInformation("FFmpeg moved to final path {FfmpegPath}", _ffmpegPath);
                    }
                }
                else
                {
                    // Linux/macOS extraction
                    var extractionDir = Path.Combine(ffmpegDir, "extracted");
                    Directory.CreateDirectory(extractionDir);

                    Logger.LogInformation("Starting extraction of FFmpeg in Linux environment.");

                    var tarProcess = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "tar",
                            Arguments = $"-xf \"{tempFilePath}\" -C \"{extractionDir}\"",
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    };

                    tarProcess.Start();
                    await tarProcess.WaitForExitAsync();

                    if (tarProcess.ExitCode != 0)
                    {
                        string error = await tarProcess.StandardError.ReadToEndAsync();
                        Logger.LogError("Error extracting FFmpeg: {Error}", error);
                        return;
                    }

                    Logger.LogInformation("FFmpeg extraction completed.");

                    // Locate the extracted FFmpeg binary
                    var extractedPath = Directory.GetFiles(extractionDir, "ffmpeg", SearchOption.AllDirectories).FirstOrDefault();
                    if (extractedPath != null)
                    {
                        File.Move(extractedPath, _ffmpegPath, true);
                        Logger.LogInformation("FFmpeg moved to final path {FfmpegPath}", _ffmpegPath);

                        // Ensure the binary is executable
                        var chmodProcess = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "chmod",
                                Arguments = $"+x \"{_ffmpegPath}\"",
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                UseShellExecute = false,
                                CreateNoWindow = true
                            }
                        };

                        chmodProcess.Start();
                        await chmodProcess.WaitForExitAsync();
                        Logger.LogInformation("Executable permissions set for FFmpeg at {FfmpegPath}", _ffmpegPath);
                    }
                    else
                    {
                        Logger.LogError("FFmpeg binary not found after extraction.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred during FFmpeg download or extraction.");
            }
            finally
            {
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                    Logger.LogInformation("Temporary download file deleted at {TempFilePath}", tempFilePath);
                }

                var extractionDir = Path.Combine(ffmpegDir, "extracted");
                if (Directory.Exists(extractionDir))
                {
                    Directory.Delete(extractionDir, true);
                    Logger.LogInformation("Temporary extraction directory deleted at {ExtractionDir}", extractionDir);
                }
            }

            Logger.LogInformation("FFmpeg download and setup complete.");
        }
        else
        {
            Logger.LogInformation("FFmpeg already exists at path {FfmpegPath}. Skipping download.", _ffmpegPath);
        }
    }
}