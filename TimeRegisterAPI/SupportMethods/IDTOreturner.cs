using TimeRegisterAPI.DTO;
using TimeRegisterAPI.DTO.CustDTO;
using TimeRegisterAPI.DTO.ProjDTO;
using TimeRegisterAPI.DTO.TimeDTO;

namespace TimeRegisterAPI.SupportMethods
{
    public interface IDTOreturner
    {
        public List<ProjectOverviewDTO> ReturnCustomerProjectDtos(int customerId);
        
        public CustomerOverviewDTO ReturnCustomerOverViewDto(int customerId);
        public List<CustomerListViewDTO> ReturnCustomerListViewDtos();
        public List<ProjectsListViewDTO> ReturnProjectListDto();

        public ProjectOverviewDTO ReturnProjOverviewDto(int id);
        public List<TimeReportListViewDTO> ReturnTimeReportListViewDtos();
        public TimeReportOverviewDTO ReturnTimeReportOverviewDto(int id);


    }
}