using System.ComponentModel.DataAnnotations;

namespace TimeRegisterAPI.DTO.ProjDTO;

public class UpdateProjectDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    [Required(ErrorMessage = "Projektnamn måste anges")]
    [MaxLength(50, ErrorMessage = "Projektnamnet får bestå av max 50 tecken")]

    public string Name { get; set; }
    [Required(ErrorMessage = "Timpris måste anges")]
    [Range(1, 50000, ErrorMessage = "Ange en summa mellan 1 och 50000")]
    public int PricePerHour { get; set; }
    public bool Active { get; set; }
}