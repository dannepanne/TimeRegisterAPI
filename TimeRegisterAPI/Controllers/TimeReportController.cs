using Microsoft.AspNetCore.Mvc;
using TimeRegisterAPI.DTO.TimeDTO;
using TimeRegisterAPI.Infrastructure.DTOReturners;
using TimeRegisterAPI.SupportMethods;

namespace TimeRegisterAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeReportController : ControllerBase
{
    private readonly ITimeRegDTOReturner _dtoReturner;
    private readonly IDBErrorHandlers _errorHandlers;
    private readonly IDbObjectMethods _objectMethods;

    public TimeReportController(ITimeRegDTOReturner dtoReturner, IDbObjectMethods objectMethods,
        IDBErrorHandlers errorHandlers)
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
            return NotFound("Id does not exist");

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
        if (_errorHandlers.ProjectIdExists(newtimereport.ProjectId))
        {
            var timerep = _objectMethods.CreateTimeReport(newtimereport);

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

        return NotFound("Project not found!");
    }

    [HttpGet]
    [Route("TimeRepPocessed")]
    public IActionResult GetProcessed()
    {
        var processed = _dtoReturner.ReturnTimeReportListViewProcessedDtos().OrderBy(x => x.ProjectName).ToList();
        return Ok(processed);
    }

    [HttpGet]
    [Route("TimeRepNotProcessed")]
    public IActionResult GetNotProcessed()
    {
        var processed = _dtoReturner.ReturnTimeReportListViewNotProcessedDtos().OrderBy(x => x.ProjectName).ToList();
        return Ok(processed);
    }

    [HttpGet]
    [Route("GetUnprocessedInvoices")]
    public IActionResult GetInvoices()
    {
        var invoices = _dtoReturner.TimeRegInvoiceReturner();
        return Ok(invoices);
    }
}


