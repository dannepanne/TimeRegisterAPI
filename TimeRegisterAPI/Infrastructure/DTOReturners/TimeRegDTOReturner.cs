using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO.TimeDTO;

namespace TimeRegisterAPI.Infrastructure.DTOReturners;

public class TimeRegDTOReturner : ITimeRegDTOReturner
{
    private readonly ApplicationDbContext _context;

    public TimeRegDTOReturner(ApplicationDbContext context)
    {
        _context = context;
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

            ;
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
}