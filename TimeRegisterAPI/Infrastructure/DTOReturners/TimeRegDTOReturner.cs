using Microsoft.EntityFrameworkCore;
using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO.TimeDTO;
using TimeRegisterAPI.SupportMethods;

namespace TimeRegisterAPI.Infrastructure.DTOReturners;

public class TimeRegDTOReturner : ITimeRegDTOReturner
{
    private readonly ApplicationDbContext _context;
    private readonly IMathHelpers _mathHelpers;

    public TimeRegDTOReturner(ApplicationDbContext context, IMathHelpers mathHelpers)
    {
        _context = context;
        _mathHelpers = mathHelpers;
    }


    public List<TimeReportListViewDTO> ReturnTimeReportListViewDtos()
    {
        var timeReportListView = new List<TimeReportListViewDTO>();
        foreach (var timerep in _context.TimeReports.ToList())
        {
            var newDto = new TimeReportListViewDTO
            {
                Date = timerep.Date,
                ProjectName = _context.Projects.FirstOrDefault(x => x.Id == timerep.ProjectId).Name,
                NoHours = timerep.NoHours,
                Processed = timerep.Processed
            };
            timeReportListView.Add(newDto);
        }

        return timeReportListView;
    }

    public List<TimeReportListViewDTO> ReturnTimeReportListViewProcessedDtos()
    {
        var timeReportListView = new List<TimeReportListViewDTO>();
        foreach (var timerep in _context.TimeReports.ToList())
        {
            if (timerep.Processed)
            {
                var newDto = new TimeReportListViewDTO
                {
                    Date = timerep.Date,
                    ProjectName = _context.Projects.FirstOrDefault(x => x.Id == timerep.ProjectId).Name,
                    NoHours = timerep.NoHours,
                    Processed = timerep.Processed
                };
                timeReportListView.Add(newDto);
            }

            ;
        }

        return timeReportListView;
    }

    public List<TimeReportListViewDTO> ReturnTimeReportListViewNotProcessedDtos()
    {
        var timeReportListView = new List<TimeReportListViewDTO>();
        foreach (var timerep in _context.TimeReports.ToList())
        {
            if (timerep.Processed == false)
            {
                var newDto = new TimeReportListViewDTO
                {
                    Date = timerep.Date,
                    ProjectName = _context.Projects.FirstOrDefault(x => x.Id == timerep.ProjectId).Name,
                    NoHours = timerep.NoHours,
                    Processed = timerep.Processed
                };
                timeReportListView.Add(newDto);
            }


        }
        
        return timeReportListView;
    }

    public TimeReportOverviewDTO ReturnTimeReportOverviewDto(int id)
    {
        var report = _context.TimeReports.FirstOrDefault(x => x.Id == id);
        var reportOverview = new TimeReportOverviewDTO
        {
            ProjectName = _context.Projects.FirstOrDefault(t => t.Id == report.ProjectId).Name,
            Date = report.Date.ToShortDateString(),
            NoHours = report.NoHours,
            Sum = report.Sum,
            Description = report.Description
        };
        return reportOverview;
    }

    public TimeReportInvoiceDTO TimeReportInvoice(Project project)
    {

        var proj = _context.Projects.Include(x => x.TimeReports).FirstOrDefault(x => x.Id == project.Id);
        List<TimeReport> unProcessed = proj.TimeReports.Where(x => x.Processed == false).ToList();
        int invoiceSum = _mathHelpers.InvoiceSum(unProcessed);

        TimeReportInvoiceDTO newDto = new TimeReportInvoiceDTO
        {
            CustomerName = _context.Customers.FirstOrDefault(x => x.Id == proj.CustomerId).Name,
            ProjectName = proj.Name,
            InvoiceSum = invoiceSum,
            TimeReports = unProcessed,
        };

        return newDto;
    }


    public List<TimeReportInvoiceDTO> TimeRegInvoiceReturner()
    {
        List<TimeReportInvoiceDTO> timeReports = new List<TimeReportInvoiceDTO>();

        foreach (var project in _context.Projects)
        {
            if (project.Active == true)
            {
                var newinvoice = TimeReportInvoice(project);
                timeReports.Add(newinvoice);
            }
        }

        return timeReports;
    }
}