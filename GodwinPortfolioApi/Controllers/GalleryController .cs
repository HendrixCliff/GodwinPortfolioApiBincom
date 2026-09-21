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