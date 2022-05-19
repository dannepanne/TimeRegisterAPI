namespace TimeRegisterAPI.DTO.TimeDTO
{
    public class CreateTimeReportDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Sum { get; set; }
        public int ProjectId { get; set; }
        public bool Processed { get; set; }
        public int NoHours { get; set; }
        public string Description { get; set; }
    }
}
