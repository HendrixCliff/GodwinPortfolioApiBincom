using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace GodwinPortfolioApi.DTOs;

public sealed class GalleryUploadRequest
{
    [Required]
    [StringLength(
        150,
        ErrorMessage = "The image title cannot exceed 150 characters.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(
        500,
        ErrorMessage = "The image description cannot exceed 500 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select an image.")]
    public IFormFile? Image { get; set; }
}