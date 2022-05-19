using Microsoft.AspNetCore.Mvc;
using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO.CustDTO;
using TimeRegisterAPI.DTO.ProjDTO;
using TimeRegisterAPI.SupportMethods;

namespace TimeRegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IDBErrorHandlers _errorHanders;
        private readonly IDbObjectMethods _objectMethods;
        private readonly IDTOreturner _dtoReturner;

        public ProjectController(IDTOreturner dtoReturner, IDbObjectMethods objectMethods, IDBErrorHandlers errorHandlers)
        {
            _errorHanders = errorHandlers;
            _objectMethods = objectMethods;
            _dtoReturner = dtoReturner;
        }



        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_dtoReturner.ReturnCustomerListViewDtos());
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
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
                TimeReports = new List<TimeReport>()
            };
            _objectMethods.SaveNewProject(proj);

            var projectOverviewDto = new ProjectOverviewDTO
            {

                ProjectName = newproj.Name,
                PricePerHour = newproj.PricePerHour,
                Description = newproj.Description,

            };
            return CreatedAtAction(nameof(GetOne), new { id = newproj.Id }, projectOverviewDto);
        }

    }
}
