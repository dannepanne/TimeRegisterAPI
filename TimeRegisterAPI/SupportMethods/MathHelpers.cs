using Microsoft.EntityFrameworkCore;
using TimeRegisterAPI.Data;

namespace TimeRegisterAPI.SupportMethods;

public class MathHelpers : IMathHelpers
{
    private readonly ApplicationDbContext _context;

    public MathHelpers(ApplicationDbContext context)
    {
        _context = context;
    }

    public int MinutesToHoursSum(int minutes, int pricePerHour)
    {
        int hourSum = (minutes / 60) * pricePerHour;
        return hourSum;
    }

    public int TimeSpentSoFar(Project project)
    {
        var proj = _context.Projects.Include(x => x.TimeReports).FirstOrDefault(p => p.Id == project.Id);
        var timeSpent = 0;
        foreach (var time in proj.TimeReports)
        {
            timeSpent = +time.NoHours;
        }
        return timeSpent;
    }

    public int HoursSum(int hours, int pricePerHour)
    {
        return hours * pricePerHour;
    }

}
