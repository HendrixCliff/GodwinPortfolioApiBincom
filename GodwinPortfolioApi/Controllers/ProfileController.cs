using GodwinPortfolioApi.Data;
using GodwinPortfolioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProfileController : ControllerBase
{
    /// <summary>
    /// Retrieves the portfolio owner's profile information.
    /// </summary>
    /// <returns>The portfolio profile.</returns>
    /// <response code="200">Profile information was successfully retrieved.</response>
    [HttpGet]
    [ProducesResponseType(
        typeof(PortfolioProfile),
        StatusCodes.Status200OK)]
    public ActionResult<PortfolioProfile> GetProfile()
    {
        var profile = PortfolioData.BuildProfile();

        return Ok(profile);
    }
}