using TimeRegisterAPI.Data;

namespace TimeRegisterAPI.DTO.CustDTO
{
    public class CreateCustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Project> Projects = new List<Project>();
    }
}
