using GodwinPortfolioApi.DTOs;

namespace GodwinPortfolioApi.Services;

public interface IGalleryService
{
    Task<IReadOnlyList<GalleryItemDto>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<GalleryItemDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<(bool Success, string? ErrorMessage, GalleryItemDto? Item)>
        UploadAsync(
            GalleryUploadRequest request,
            CancellationToken cancellationToken = default);

    Task<(bool Success, string? ErrorMessage)> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}