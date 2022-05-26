using System.ComponentModel.DataAnnotations;

namespace TimeRegisterAPI.DTO.CustDTO;

public class UpdateCustomerDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Kundnamn måste anges")]
    [MinLength(3, ErrorMessage = "Kundnamn måste bestå av minst tre tecken")]
    [MaxLength(50, ErrorMessage = "Kundnamn får bestå av max 50 tecken")]
    public string Name { get; set; }
}