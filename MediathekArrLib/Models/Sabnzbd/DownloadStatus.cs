namespace MediathekArr.Models.Sabnzbd;

/// <summary>
/// Download Status
/// </summary>
public enum DownloadStatus
{
    /// <summary>
    /// Download completed
    /// </summary>
    Completed,

    /// <summary>
    /// Download failed
    /// </summary>
    Failed,

    /// <summary>
    /// Actively downloading
    /// </summary>
    Downloading,

    /// <summary>
    /// Queued for Downloading
    /// </summary>
    Queued,

    /// <summary>
    /// Extracting/Processing downloaded files
    /// </summary>
    Extracting
}