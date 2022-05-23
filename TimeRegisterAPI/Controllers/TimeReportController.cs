using Microsoft.AspNetCore.Mvc;
using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO.ProjDTO;
using TimeRegisterAPI.DTO.TimeDTO;
using TimeRegisterAPI.SupportMethods;

namespace TimeRegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportController : ControllerBase
    {
        private readonly IDbObjectMethods _objectMethods;
        private readonly IDTOreturner _dtoReturner;
        private readonly IDBErrorHandlers _errorHandlers;

        public TimeReportController(IDTOreturner dtoReturner, IDbObjectMethods objectMethods, IDBErrorHandlers errorHandlers)
        {
            _errorHandlers = errorHandlers;
            _objectMethods = objectMethods;
            _dtoReturner = dtoReturner;
            
        }


        [HttpGet] 
        public IActionResult Index()
        {
            return Ok(_dtoReturner.ReturnTimeReportListViewDtos());
        }


        [HttpGet] 
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            if (_errorHandlers.TimeRepIdExists(id) == false)
            return this.NotFound("Id does not exist");

            var report = _dtoReturner.ReturnTimeReportOverviewDto(id);
            if (report == null)
                return NotFound();

            return Ok(report);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateTimeReportDTO thisTimeReport)
        {
            if (_objectMethods.UpdateTimeReport(id, thisTimeReport) == false) return NotFound();
            _objectMethods.UpdateTimeReport(id, thisTimeReport);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(CreateTimeReportDTO newtimereport)
        {
            var timerep = _objectMethods.CreateTimeReport(newtimereport);
            if (_errorHandlers.TimeRepIdExists(timerep.Id) == true)
            {
                var timereportOverviewDto = new TimeReportOverviewDTO
                {
                    ProjectName = _objectMethods.ReturnProjectName(timerep.ProjectId),
                    Date = timerep.Date.ToShortDateString(),
                    Description = timerep.Description,
                    NoHours = timerep.NoHours,
                    Sum = timerep.Sum

                };
                return CreatedAtAction(nameof(GetOne), new { id = timerep.Id }, timereportOverviewDto);
            }

            return NotFound();
        }



    }
}
