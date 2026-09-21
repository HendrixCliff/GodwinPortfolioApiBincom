using GodwinPortfolioApi.Data;
using GodwinPortfolioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProfileController : ControllerBase
{
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