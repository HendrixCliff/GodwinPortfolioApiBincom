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
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? builder.Configuration["ConnectionStrings_DefaultConnection"];

if (string.IsNullOrWhiteSpace(databaseConnectionString))
{
    throw new InvalidOperationException(
        "Connection string is not configured.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        databaseConnectionString,
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null);
        });
});

var blobConnectionString =
    builder.Configuration["AzureBlobStorage:ConnectionString"]
    ?? builder.Configuration["AzureBlobStorageConnectionString"];

if (string.IsNullOrWhiteSpace(blobConnectionString))
{
    throw new InvalidOperationException(
        "Azure Blob Storage connection string is not configured.");
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