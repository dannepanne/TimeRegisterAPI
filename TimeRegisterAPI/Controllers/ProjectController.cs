using Microsoft.AspNetCore.Mvc;
using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO.ProjDTO;
using TimeRegisterAPI.Infrastructure.DTOReturners;
using TimeRegisterAPI.SupportMethods;

namespace TimeRegisterAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectDTOReturner _dtoReturner;
    private readonly IDBErrorHandlers _errorHandlers;
    private readonly IDbObjectMethods _objectMethods;

    public ProjectController(IProjectDTOReturner dtoReturner, IDbObjectMethods objectMethods,
        IDBErrorHandlers errorHandlers)
    {
        _errorHandlers = errorHandlers;
        _objectMethods = objectMethods;
        _dtoReturner = dtoReturner;
    }


    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_dtoReturner.ReturnProjectListDto().OrderBy(x => x.CustomerName).ToList());
    }


    [HttpGet]
    [Route("{id}")]
    public IActionResult GetOne(int id)
    {
        if (_errorHandlers.ProjectIdExists(id) == false)
            return NotFound("Id does not exist");

        var project = _dtoReturner.ReturnProjOverviewDto(id);
        if (project == null)
            return NotFound();

        return Ok(project);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(int id, UpdateProjectDTO thisProj)
    {
        if (_objectMethods.UpdateProject(id, thisProj) == false) return NotFound();
        _objectMethods.UpdateProject(id, thisProj);
        return NoContent();
    }

    [HttpPost]
    public IActionResult Create(CreateProjectDTO newproj)
    {
        var proj = new Project
        {
            Name = newproj.Name,
            Description = newproj.Description,
            PricePerHour = newproj.PricePerHour,
            CustomerId = newproj.CustomerId,
            Active = true,
            EndDate = newproj.EndDate,
            TimeReports = new List<TimeReport>()
        };
        _objectMethods.SaveNewProject(proj);

        var projectOverviewDto = new ProjectOverviewDTO
        {
            ProjectName = newproj.Name,
            PricePerHour = newproj.PricePerHour,
            Description = newproj.Description,
            EndDate = newproj.EndDate
        };
        return CreatedAtAction(nameof(GetOne), new { id = newproj.Id }, projectOverviewDto);
    }

    [HttpGet]
    [Route("ActiveProjects")]
    public IActionResult GetActiveProjects()
    {
        var returnList = _dtoReturner.ReturnActiveProjectsDto();
        return Ok(returnList);
    }

    [HttpGet]
    [Route("FinishedProjects")]
    public IActionResult GetFinishedProjects()
    {
        var returnList = _dtoReturner.ReturnFinishedProjectsDto();
        if (returnList != null) return Ok(returnList);
        return NotFound("There are no finished projects");
    }
}