namespace TimeRegisterAPI.DTO.TimeDTO;

public class TimeReportOverviewDTO
{
    public int Id { get; set; }

    public string ProjectName { get; set; }
    public int Sum { get; set; }
    public int NoHours { get; set; }
    public string Date { get; set; }
    public string Description { get; set; }
}