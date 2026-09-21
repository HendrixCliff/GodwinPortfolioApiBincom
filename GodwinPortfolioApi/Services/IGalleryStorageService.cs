using Microsoft.AspNetCore.Http;

namespace GodwinPortfolioApi.Services;

public interface IGalleryStorageService
{
    Task<string> UploadAsync(
        IFormFile file,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        string blobName,
        CancellationToken cancellationToken = default);

    string GetBlobUrl(string blobName);
}