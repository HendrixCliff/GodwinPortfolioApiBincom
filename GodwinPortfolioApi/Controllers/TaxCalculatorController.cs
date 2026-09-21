using GodwinPortfolioApi.DTOs;
using GodwinPortfolioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TaxCalculatorController
    : ControllerBase
{
    private readonly ITaxCalculatorService
        _taxCalculatorService;

    public TaxCalculatorController(
        ITaxCalculatorService taxCalculatorService)
    {
        _taxCalculatorService =
            taxCalculatorService;
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(TaxCalculatorResponse),
        StatusCodes.Status200OK)]
    [ProducesResponseType(
        StatusCodes.Status400BadRequest)]
    public ActionResult<TaxCalculatorResponse> Calculate(
        [FromBody] TaxCalculatorRequest request)
    {
        var result =
            _taxCalculatorService.Calculate(request);

        return Ok(result);
    }
}