namespace GodwinPortfolioApi.DTOs;

public sealed class GalleryItemDto
{
    /// <summary>
    /// Unique identifier of the gallery item.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Display title of the image.
    /// </summary>
    public string Title { get; init; } = string.Empty;

    /// <summary>
    /// Description of the image.
    /// </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// Original uploaded file name.
    /// </summary>
    public string FileName { get; init; } = string.Empty;

    /// <summary>
    /// MIME type of the image.
    /// </summary>
    public string ContentType { get; init; } = string.Empty;

    /// <summary>
    /// Image size in bytes.
    /// </summary>
    public long FileSize { get; init; }

    /// <summary>
    /// Date and time when the image was uploaded.
    /// </summary>
    public DateTime UploadedAt { get; init; }

    /// <summary>
    /// Public URL of the image stored in Azure Blob Storage.
    /// </summary>
    public string ImageUrl { get; init; } = string.Empty;
}