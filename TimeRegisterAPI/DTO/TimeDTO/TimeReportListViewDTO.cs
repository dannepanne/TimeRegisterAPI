namespace TimeRegisterAPI.DTO.TimeDTO
{
    public class TimeReportListViewDTO
    {
        public DateTime Date { get; set; }
        public bool Processed { get; set; }
        public int NoHours { get; set; }
        public string ProjectName { get; set; }
    }
}
