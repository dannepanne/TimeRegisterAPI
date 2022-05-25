using TimeRegisterAPI.Data;

namespace TimeRegisterAPI.DTO.ProjDTO;

public class CreateProjectDTO
{
    public List<TimeReport> TimeReports = new();
    public int Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public int PricePerHour { get; set; }
    public int CustomerId { get; set; }
    public bool Active { get; set; }
    public DateTime EndDate { get; set; }
}