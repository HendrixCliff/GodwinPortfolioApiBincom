using GodwinPortfolioApi.Data;
using GodwinPortfolioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ExperienceController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(
        typeof(IEnumerable<Experience>),
        StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Experience>> GetExperience()
    {
        var experience = PortfolioData.BuildExperience();

        return Ok(experience);
    }
}