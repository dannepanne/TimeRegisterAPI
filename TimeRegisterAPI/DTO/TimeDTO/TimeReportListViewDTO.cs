namespace TimeRegisterAPI.DTO.TimeDTO;

public class TimeReportListViewDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool Processed { get; set; }
    public int NoHours { get; set; }
    public string ProjectName { get; set; }
}