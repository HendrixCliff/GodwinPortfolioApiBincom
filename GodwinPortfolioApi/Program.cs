using Azure.Storage.Blobs;
using GodwinPortfolioApi.Data;
using GodwinPortfolioApi.Repositories;
using GodwinPortfolioApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var databaseConnectionString =
    builder.Configuration.GetConnectionString(
        "DefaultConnection");

if (string.IsNullOrWhiteSpace(databaseConnectionString))
{
    throw new InvalidOperationException(
        "ConnectionStrings:DefaultConnection is not configured.");
}

builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseSqlServer(
            databaseConnectionString,
            sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay:
                        TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
            });
    });



var blobConnectionString =
    builder.Configuration[
        "AzureBlobStorage:ConnectionString"];

if (string.IsNullOrWhiteSpace(blobConnectionString))
{
    throw new InvalidOperationException(
        "AzureBlobStorage:ConnectionString is not configured.");
}

builder.Services.AddSingleton(
    new BlobServiceClient(blobConnectionString));



builder.Services.AddScoped<
    IGalleryRepository,
    GalleryRepository>();

builder.Services.AddScoped<
    IGalleryService,
    GalleryService>();

builder.Services.AddScoped<
    IGalleryStorageService,
    AzureBlobStorageService>();



builder.Services.AddScoped<
    ITaxCalculatorService,
    TaxCalculatorService>();

var app = builder.Build();




app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();