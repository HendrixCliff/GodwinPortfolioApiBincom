using GodwinPortfolioApi.Data;
using GodwinPortfolioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class SkillsController : ControllerBase
{
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