namespace MediathekArr.Configuration;

/// <summary>
/// Configuration for the Downloader service.
/// </summary>
/// <remarks>
/// This class holds paths for incomplete and complete downloads, as well as categories.
/// It is used to configure the downloader's behavior and can be extended in the future.
/// The properties are designed to be set via environment variables or directly in the code.
/// </remarks>
public record DownloaderConfiguration
{
    /// <summary>
    /// Gets or sets the path for incomplete downloads.
    /// This path is used to store files that are still being downloaded.
    /// It can be overridden by the environment variable DOWNLOAD_INCOMPLETE_PATH.
    /// </summary>
    public string IncompletePath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the path for complete downloads.
    /// This path is used to store files that have been fully downloaded.
    /// It can be overridden by the environment variable DOWNLOAD_COMPLETE_PATH.
    /// </summary>
    public string CompletePath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the categories for downloaded content.
    /// These categories help organize downloaded files into different directories.
    /// The categories can be overridden by the environment variable CATEGORIES.
    /// </summary>
    public string[] Categories { get; set; } = ["tv", "movies", "mediathek"];
}
