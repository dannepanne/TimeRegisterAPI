using TimeRegisterAPI.DTO.CustDTO;
using TimeRegisterAPI.DTO.ProjDTO;
using TimeRegisterAPI.DTO.TimeDTO;

namespace TimeRegisterAPI.SupportMethods.DTOReturners
{
    public interface ICustomerDTOReturner
    {

        public CustomerOverviewDTO ReturnCustomerOverViewDto(int customerId);
        public List<CustomerListViewDTO> ReturnCustomerListViewDtos();

        public List<ProjectsListViewDTO> ReturnCustomerProjectDtos(int customerId);





    }
}