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

    /// <summary>
    /// Calculates annual and monthly personal income tax.
    /// </summary>
    /// <remarks>
    /// The calculation applies the configured progressive tax bands
    /// and eligible deductions supplied in the request.
    /// </remarks>
    /// <param name="request">Income, rent and eligible deductions.</param>
    /// <returns>The calculated tax breakdown.</returns>
    /// <response code="200">Tax was successfully calculated.</response>
    /// <response code="400">The supplied financial values are invalid.</response>
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