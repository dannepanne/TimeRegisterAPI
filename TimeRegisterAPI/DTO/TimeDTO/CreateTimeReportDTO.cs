using System.ComponentModel.DataAnnotations;

namespace TimeRegisterAPI.DTO.TimeDTO;

public class CreateTimeReportDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Sum { get; set; }
    [Required(ErrorMessage= "Måste kopplas till ett existerande projekt")]
    public int ProjectId { get; set; }
    public bool Processed { get; set; }
    [Required(ErrorMessage = "Tidsåtgång måste anges")]
    public int NoHours { get; set; }
    public string Description { get; set; }
}