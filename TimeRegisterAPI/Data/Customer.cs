using System.ComponentModel.DataAnnotations;

namespace TimeRegisterAPI.Data;

public class Customer
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    public List<Project> Projects { get; set; } = new();
}