namespace TimeRegisterAPI.Data
{
    public class Project
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int PricePerHour { get; set; }
        public int CustomerId { get; set; }
        public bool Active { get; set; }
        public List<TimeReport> TimeReports { get; set; } = new List<TimeReport>();
        
    }
}
