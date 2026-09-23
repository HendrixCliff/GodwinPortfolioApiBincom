using GodwinPortfolioApi.DTOs;
using GodwinPortfolioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class GalleryController : ControllerBase
{
    private readonly IGalleryService _galleryService;

    public GalleryController(
        IGalleryService galleryService)
    {
        _galleryService = galleryService;
    }
    /// <summary>
    /// Retrieves all gallery images.
    /// </summary>
    /// <returns>A collection of gallery images.</returns>
    /// <response code="200">Gallery images were successfully retrieved.</response>
    [HttpGet]
    [ProducesResponseType(
        typeof(IReadOnlyList<GalleryItemDto>),
        StatusCodes.Status200OK)]
    public async Task<
        ActionResult<IReadOnlyList<GalleryItemDto>>> GetAll(
            CancellationToken cancellationToken)
    {
        var items =
            await _galleryService.GetAllAsync(
                cancellationToken);

        return Ok(items);
    }
    /// <summary>
    /// Retrieves a gallery image by its identifier.
    /// </summary>
    /// <param name="id">The unique gallery item identifier.</param>
    /// <returns>The requested gallery image.</returns>
    /// <response code="200">The gallery item was found.</response>
    /// <response code="404">No gallery item exists with the specified identifier.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(
        typeof(GalleryItemDto),
        StatusCodes.Status200OK)]
    [ProducesResponseType(
        StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GalleryItemDto>> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        var item =
            await _galleryService.GetByIdAsync(
                id,
                cancellationToken);

        if (item is null)
        {
            return NotFound(new
            {
                message =
                    $"Gallery item with ID {id} was not found."
            });
        }

        return Ok(item);
    }
    /// <summary>
    /// Retrieves a gallery image by its identifier.
    /// </summary>
    /// <param name="id">The unique gallery item identifier.</param>
    /// <returns>The requested gallery image.</returns>
    /// <response code="200">The gallery item was found.</response>
    /// <response code="404">No gallery item exists with the specified identifier.</response>
    [HttpPost]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(
        typeof(GalleryItemDto),
        StatusCodes.Status201Created)]
    [ProducesResponseType(
        StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GalleryItemDto>> Upload(
        [FromForm] GalleryUploadRequest request,
        CancellationToken cancellationToken)
    {
        var result =
            await _galleryService.UploadAsync(
                request,
                cancellationToken);

        if (!result.Success)
        {
            return BadRequest(new
            {
                message = result.ErrorMessage
            });
        }

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Item!.Id },
            result.Item);
    }
    /// <summary>
    /// Deletes a gallery image.
    /// </summary>
    /// <param name="id">The unique gallery item identifier.</param>
    /// <response code="204">The gallery item was successfully deleted.</response>
    /// <response code="404">The gallery item was not found.</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(
        StatusCodes.Status204NoContent)]
    [ProducesResponseType(
        StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        int id,
        CancellationToken cancellationToken)
    {
        var result =
            await _galleryService.DeleteAsync(
                id,
                cancellationToken);

        if (!result.Success)
        {
            return NotFound(new
            {
                message = result.ErrorMessage
            });
        }

        return NoContent();
    }
}