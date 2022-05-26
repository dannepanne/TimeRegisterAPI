using System.ComponentModel.DataAnnotations;
using TimeRegisterAPI.Data;

namespace TimeRegisterAPI.DTO.ProjDTO;

public class CreateProjectDTO
{
    public List<TimeReport> TimeReports = new();
    public int Id { get; set; }
    public string Description { get; set; }
    [Required(ErrorMessage = "Projektnamn måste anges")]
    [MaxLength(50, ErrorMessage = "Projektnamnet får bestå av max 50 tecken")]

    public string Name { get; set; }
    [Range(1, 50000, ErrorMessage = "Ange en summa mellan 1 och 50000")]

    public int PricePerHour { get; set; }
    [Required(ErrorMessage = "Projektet måste tillhöra en existerande kund")]

    public int CustomerId { get; set; }
    public bool Active { get; set; }
    public DateTime EndDate { get; set; }
}