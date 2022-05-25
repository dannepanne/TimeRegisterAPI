namespace TimeRegisterAPI.Data;

public class TimeReport
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Sum { get; set; }

    public int ProjectId { get; set; }
    public bool Processed { get; set; }
    public int NoHours { get; set; }
    public string Description { get; set; }

    public int CustomerId { get; set; }
}