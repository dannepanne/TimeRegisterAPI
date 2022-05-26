namespace TimeRegisterAPI.DTO.ProjDTO;

public class ProjectsListViewDTO
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public string CustomerName { get; set; }
    public DateTime EndDate { get; set; }
}