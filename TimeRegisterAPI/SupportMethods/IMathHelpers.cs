using TimeRegisterAPI.Data;

namespace TimeRegisterAPI.SupportMethods
{
    public interface IMathHelpers
    {
        public int MinutesToHoursSum(int minutes, int chargePerHour);
        public int TimeSpentSoFar(Project project);
        public int HoursSum(int hours, int chargePerHour);


    }
}