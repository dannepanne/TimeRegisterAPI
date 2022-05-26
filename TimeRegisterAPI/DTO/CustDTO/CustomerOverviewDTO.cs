using TimeRegisterAPI.DTO.ProjDTO;

namespace TimeRegisterAPI.DTO.CustDTO;

public class CustomerOverviewDTO
{
    public int Id { get; set; }
    public string CustomerName { get; set; }

    public List<ProjectsListViewDTO> Projects { get; set; }
}