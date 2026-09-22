using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace GodwinPortfolioApi.Services;

public sealed class AzureBlobStorageService
    : IGalleryStorageService
{
    private readonly BlobContainerClient _containerClient;

    public AzureBlobStorageService(
        BlobServiceClient blobServiceClient,
        IConfiguration configuration)
    {
        var containerName =
        configuration["AzureBlobStorage:ContainerName"]
        ?? configuration["AzureBlobStorageContainerName"];

        if (string.IsNullOrWhiteSpace(containerName))
        {
            throw new InvalidOperationException(
                "Azure Blob Storage container name is not configured.");
        }

        _containerClient =
            blobServiceClient.GetBlobContainerClient(containerName);
    }

    public async Task<string> UploadAsync(
        IFormFile file,
        CancellationToken cancellationToken = default)
    {
        await _containerClient.CreateIfNotExistsAsync(
            cancellationToken: cancellationToken);

        var extension =
            Path.GetExtension(file.FileName)
                .ToLowerInvariant();

        var blobName =
            $"{Guid.NewGuid():N}{extension}";

        var blobClient =
            _containerClient.GetBlobClient(blobName);

        await using var stream =
            file.OpenReadStream();

        var options = new BlobUploadOptions
        {
            HttpHeaders = new BlobHttpHeaders
            {
                ContentType = file.ContentType
            }
        };

        await blobClient.UploadAsync(
            stream,
            options,
            cancellationToken);

        return blobName;
    }

    public async Task DeleteAsync(
        string blobName,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(blobName))
        {
            return;
        }

        var blobClient =
            _containerClient.GetBlobClient(blobName);

        await blobClient.DeleteIfExistsAsync(
            cancellationToken: cancellationToken);
    }

    public string GetBlobUrl(string blobName)
    {
        var blobClient =
            _containerClient.GetBlobClient(blobName);

        return blobClient.Uri.ToString();
    }
}