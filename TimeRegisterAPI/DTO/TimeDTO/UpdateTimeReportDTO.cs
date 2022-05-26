using System.ComponentModel.DataAnnotations;

namespace TimeRegisterAPI.DTO.TimeDTO;

public class UpdateTimeReportDTO
{
    public int Id { get; set; }
    public int Sum { get; set; }
    public bool Processed { get; set; }
    [Required(ErrorMessage = "Tidsåtgång måste anges")]
    [Range(0, 100, ErrorMessage = "Tid måste anges i timmar, 0-100")]

    public int NoHours { get; set; }
    public string Description { get; set; }
}