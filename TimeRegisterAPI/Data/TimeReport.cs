using System.ComponentModel.DataAnnotations;

namespace TimeRegisterAPI.Data;

public class TimeReport
{
    public int Id { get; set; }
    [Required]
    public DateTime Date { get; set; } = DateTime.Now;
    public int Sum { get; set; }
    [Required]
    public int ProjectId { get; set; }
    [Required]
    public bool Processed { get; set; } = false;
    [Range(0,100)]
    public int NoHours { get; set; }
    public string Description { get; set; }
    [Required]
    public int CustomerId { get; set; }
}