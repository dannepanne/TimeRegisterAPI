using System.ComponentModel.DataAnnotations;

namespace TimeRegisterAPI.Data;

public class Project
{
    public int Id { get; set; }
    public string Description { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Range(1,50000)]
    public int PricePerHour { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public bool Active { get; set; }
    public List<TimeReport> TimeReports { get; set; } = new();
}