using System.ComponentModel.DataAnnotations;
using TimeRegisterAPI.Data;

namespace TimeRegisterAPI.DTO.ProjDTO;

public class CreateProjectDTO
{
    public List<TimeReport> TimeReports = new();
    public int Id { get; set; }
    public string Description { get; set; }
    [Required(ErrorMessage = "Projektnamn måste anges")]

    public string Name { get; set; }
    public int PricePerHour { get; set; }
    [Required(ErrorMessage = "Projektet måste tillhöra en existerande kund")]

    public int CustomerId { get; set; }
    public bool Active { get; set; }
    public DateTime EndDate { get; set; }
}