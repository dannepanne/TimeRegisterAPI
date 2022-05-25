using TimeRegisterAPI.Data;

namespace TimeRegisterAPI.DTO.CustDTO;

public class CreateCustomerDTO
{
    public List<Project> Projects = new();
    public int Id { get; set; }

    public string Name { get; set; }
}