using GodwinPortfolioApi.DTOs;
using GodwinPortfolioApi.Models;
using GodwinPortfolioApi.Repositories;

namespace GodwinPortfolioApi.Services;

public sealed class GalleryService : IGalleryService
{
    private static readonly HashSet<string> AllowedExtensions =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".gif",
            ".webp"
        };

    private static readonly HashSet<string> AllowedContentTypes =
        new(StringComparer.OrdinalIgnoreCase)
        {
            "image/jpeg",
            "image/png",
            "image/gif",
            "image/webp"
        };

    private const long MaximumFileSize =
        5 * 1024 * 1024;

    private readonly IGalleryRepository _repository;
    private readonly IGalleryStorageService _storage;

    public GalleryService(
        IGalleryRepository repository,
        IGalleryStorageService storage)
    {
        _repository = repository;
        _storage = storage;
    }

    public async Task<IReadOnlyList<GalleryItemDto>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var items =
            await _repository.GetAllAsync(cancellationToken);

        return items
            .Select(MapToDto)
            .ToList();
    }

    public async Task<GalleryItemDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var item =
            await _repository.GetByIdAsync(
                id,
                cancellationToken);

        return item is null
            ? null
            : MapToDto(item);
    }

    public async Task<(
        bool Success,
        string? ErrorMessage,
        GalleryItemDto? Item)> UploadAsync(
            GalleryUploadRequest request,
            CancellationToken cancellationToken = default)
    {
        var validationError =
            ValidateUpload(request);

        if (validationError is not null)
        {
            return (false, validationError, null);
        }

        var image = request.Image!;

        var blobName =
            await _storage.UploadAsync(
                image,
                cancellationToken);

        try
        {
            var galleryItem = new GalleryItem
            {
                Title = request.Title.Trim(),
                Description =
                    request.Description?.Trim() ?? string.Empty,
                FileName =
                    Path.GetFileName(image.FileName),
                ContentType = image.ContentType,
                FileSize = image.Length,
                BlobName = blobName,
                UploadedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(
                galleryItem,
                cancellationToken);

            await _repository.SaveChangesAsync(
                cancellationToken);

            return (
                true,
                null,
                MapToDto(galleryItem));
        }
        catch
        {
            await _storage.DeleteAsync(
                blobName,
                cancellationToken);

            throw;
        }
    }

    public async Task<(bool Success, string? ErrorMessage)>
        DeleteAsync(
            int id,
            CancellationToken cancellationToken = default)
    {
        var galleryItem =
            await _repository.GetByIdAsync(
                id,
                cancellationToken);

        if (galleryItem is null)
        {
            return (
                false,
                $"Gallery item with ID {id} was not found.");
        }

        _repository.Delete(galleryItem);

        await _repository.SaveChangesAsync(
            cancellationToken);

        await _storage.DeleteAsync(
            galleryItem.BlobName,
            cancellationToken);

        return (true, null);
    }

    private static string? ValidateUpload(
        GalleryUploadRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return "Please enter an image title.";
        }

        if (request.Title.Trim().Length > 150)
        {
            return "The image title cannot exceed 150 characters.";
        }

        if (request.Description?.Length > 500)
        {
            return "The image description cannot exceed 500 characters.";
        }

        if (request.Image is null ||
            request.Image.Length == 0)
        {
            return "Please select an image.";
        }

        if (request.Image.Length > MaximumFileSize)
        {
            return "The image must be 5 MB or smaller.";
        }

        var extension =
            Path.GetExtension(request.Image.FileName);

        if (!AllowedExtensions.Contains(extension))
        {
            return
                "Only JPG, JPEG, PNG, GIF and WEBP images are allowed.";
        }

        if (!AllowedContentTypes.Contains(
                request.Image.ContentType))
        {
            return
                "The uploaded file must be a supported image type.";
        }

        return null;
    }

    private GalleryItemDto MapToDto(
        GalleryItem galleryItem)
    {
        return new GalleryItemDto
        {
            Id = galleryItem.Id,
            Title = galleryItem.Title,
            Description = galleryItem.Description,
            FileName = galleryItem.FileName,
            ContentType = galleryItem.ContentType,
            FileSize = galleryItem.FileSize,
            UploadedAt = galleryItem.UploadedAt,
            ImageUrl =
                _storage.GetBlobUrl(
                    galleryItem.BlobName)
        };
    }
}