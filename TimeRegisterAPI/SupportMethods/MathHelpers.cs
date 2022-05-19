using TimeRegisterAPI.Data;

namespace TimeRegisterAPI.SupportMethods;

public class MathHelpers : IMathHelpers
{

    public int MinutesToHoursSum(int minutes, int pricePerHour)
    {
        int hourSum = (minutes / 60) * pricePerHour;
        return hourSum;
    }

    public int TimeSpentSoFar(Project project)
    {
        var timeSpent = 0;
        foreach (var time in project.TimeReports)
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
