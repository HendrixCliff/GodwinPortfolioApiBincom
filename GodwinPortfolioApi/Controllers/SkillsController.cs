using GodwinPortfolioApi.Data;
using GodwinPortfolioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class SkillsController : ControllerBase
{
    /// <summary>
    /// Retrieves the technical skills grouped by category.
    /// </summary>
    /// <returns>A collection of technical skill groups.</returns>
    /// <response code="200">Skills were successfully retrieved.</response>
    [HttpGet]
    [ProducesResponseType(
        typeof(IEnumerable<SkillGroup>),
        StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<SkillGroup>> GetSkills()
    {
        var skills = PortfolioData.BuildSkills();

        return Ok(skills);
    }
}