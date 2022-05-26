using System.ComponentModel.DataAnnotations;
using TimeRegisterAPI.Data;

namespace TimeRegisterAPI.DTO.CustDTO;

public class CreateCustomerDTO
{
    public List<Project> Projects = new();
    public int Id { get; set; }
    [Required(ErrorMessage = "Kundnamn måste anges")]
    [MinLength(3, ErrorMessage = "Kundnamn måste bestå av minst tre tecken")]
    public string Name { get; set; }
}