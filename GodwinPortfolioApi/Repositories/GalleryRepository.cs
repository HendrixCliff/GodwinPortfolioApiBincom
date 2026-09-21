using GodwinPortfolioApi.Data;
using GodwinPortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GodwinPortfolioApi.Repositories;

public sealed class GalleryRepository : IGalleryRepository
{
    private readonly ApplicationDbContext _context;

    public GalleryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GalleryItem>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.GalleryItems
            .AsNoTracking()
            .OrderByDescending(x => x.UploadedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<GalleryItem?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await _context.GalleryItems
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task AddAsync(
        GalleryItem galleryItem,
        CancellationToken cancellationToken = default)
    {
        await _context.GalleryItems.AddAsync(
            galleryItem,
            cancellationToken);
    }

    public void Delete(GalleryItem galleryItem)
    {
        _context.GalleryItems.Remove(galleryItem);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}