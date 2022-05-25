using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO.CustDTO;
using TimeRegisterAPI.DTO.ProjDTO;
using TimeRegisterAPI.DTO.TimeDTO;

namespace TimeRegisterAPI.SupportMethods;

public class DbObjectMethods : IDbObjectMethods
{
    private readonly ApplicationDbContext _context;
    private readonly IMathHelpers _mathHelpers;

    public DbObjectMethods(ApplicationDbContext context, IMathHelpers mathHelpers)
    {
        _mathHelpers = mathHelpers;
        _context = context;
    }

    public bool UpdateCustomer(int id, UpdateCustomerDTO thiscust)
    {
        var cust = _context.Customers.FirstOrDefault(t => t.Id == id);
        if (cust == null)
            return false;
        cust.Name = thiscust.Name;
        _context.SaveChanges();
        return true;
    }

    public void SaveNewCustomer(Customer cust)
    {
        _context.Customers.Add(cust);
        _context.SaveChanges();
    }

    public bool UpdateProject(int id, UpdateProjectDTO thisproj)
    {
        var proj = _context.Projects.FirstOrDefault(t => t.Id == id);
        if (proj == null)
            return false;
        proj.Name = thisproj.Name;
        proj.Description = thisproj.Description;
        proj.PricePerHour = thisproj.PricePerHour;
        _context.SaveChanges();
        return true;
    }

    public void SaveNewProject(Project proj)
    {
        _context.Projects.Add(proj);
        _context.SaveChanges();
    }


    public bool UpdateTimeReport(int id, UpdateTimeReportDTO thisreport)
    {
        var report = _context.TimeReports.FirstOrDefault(t => t.Id == id);
        var project = _context.Projects.FirstOrDefault(t => t.Id == report.ProjectId);
        if (report == null)
            return false;
        report.Description = thisreport.Description;
        report.NoHours = thisreport.NoHours;
        report.Processed = thisreport.Processed;
        report.Sum = _mathHelpers.HoursSum(report.NoHours, project.PricePerHour);

        _context.SaveChanges();
        return true;
    }

    public void SaveNewProject(TimeReport timereport)
    {
        _context.TimeReports.Add(timereport);
        _context.SaveChanges();
    }


    public CreateTimeReportDTO CreateTimeReport(CreateTimeReportDTO timerep)
    {
        var newreport = new TimeReport
        {
            Description = timerep.Description,
            Date = DateTime.Today,
            NoHours = timerep.NoHours,
            ProjectId = timerep.ProjectId,
            Processed = false,
            Sum = _mathHelpers.HoursSum(8, _context.Projects.FirstOrDefault(e => e.Id == 2).PricePerHour),
            CustomerId = _context.Projects.FirstOrDefault(e => e.Id == timerep.ProjectId).CustomerId
        };
        SaveNewProject(newreport);
        return timerep;
    }

    public string ReturnProjectName(int timerepid)
    {
        var projname = _context.Projects.FirstOrDefault(e => e.Id == timerepid).Name;
        return projname;
    }
}