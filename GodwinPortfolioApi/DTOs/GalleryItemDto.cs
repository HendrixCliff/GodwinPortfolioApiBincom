namespace GodwinPortfolioApi.DTOs;

public sealed class GalleryItemDto
{
    public int Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public string FileName { get; init; } = string.Empty;

    public string ContentType { get; init; } = string.Empty;

    public long FileSize { get; init; }

    public DateTime UploadedAt { get; init; }

    public string ImageUrl { get; init; } = string.Empty;
}