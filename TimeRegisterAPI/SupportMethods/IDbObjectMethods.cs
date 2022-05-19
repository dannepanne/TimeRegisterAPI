using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO;
using TimeRegisterAPI.DTO.CustDTO;
using TimeRegisterAPI.DTO.ProjDTO;
using TimeRegisterAPI.DTO.TimeDTO;

namespace TimeRegisterAPI.SupportMethods
{
    public interface IDbObjectMethods
    {
        public bool UpdateCustomer(int id, UpdateCustomerDTO thiscust);
        public void SaveNewCustomer(Customer cust);
        public bool UpdateProject(int id, UpdateProjectDTO thisproj);
        public void SaveNewProject(Project proj);

        public bool UpdateTimeReport(int id, UpdateTimeReportDTO thisreport);
        public void SaveNewProject(TimeReport timereport);
        public CreateTimeReportDTO CreateTimeReport(CreateTimeReportDTO timerep);
        public string ReturnProjectName(int timerepid)



    }
}