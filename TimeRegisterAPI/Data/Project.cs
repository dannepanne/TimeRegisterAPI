﻿namespace TimeRegisterAPI.Data
{
    public class Project
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int CostPerHour { get; set; }
        public List<TimeReport> TimeReports { get; set; } = new List<TimeReport>();
        
    }
}
