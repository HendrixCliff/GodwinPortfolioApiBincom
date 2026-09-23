using GodwinPortfolioApi.Data;
using GodwinPortfolioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProjectsController : ControllerBase
{
    /// <summary>
    /// Retrieves the projects included in the portfolio.
    /// </summary>
    /// <returns>A collection of portfolio projects.</returns>
    /// <response code="200">Projects were successfully retrieved.</response>
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