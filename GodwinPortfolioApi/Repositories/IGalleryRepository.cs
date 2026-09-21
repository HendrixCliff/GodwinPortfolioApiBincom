using GodwinPortfolioApi.Models;

namespace GodwinPortfolioApi.Repositories;

public interface IGalleryRepository
{
    Task<List<GalleryItem>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<GalleryItem?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        GalleryItem galleryItem,
        CancellationToken cancellationToken = default);

    void Delete(GalleryItem galleryItem);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
}