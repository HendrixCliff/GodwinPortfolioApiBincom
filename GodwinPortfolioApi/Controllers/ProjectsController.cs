using GodwinPortfolioApi.Data;
using GodwinPortfolioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProjectsController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(
        typeof(IEnumerable<Project>),
        StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Project>> GetProjects()
    {
        var projects = PortfolioData.BuildProjects();

        return Ok(projects);
    }
}