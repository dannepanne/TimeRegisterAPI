﻿namespace TimeRegisterAPI.Data
{
    public class TimeReport
    {
        
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Sum { get; set; }
        public int ProjectId { get; set; }

        public int NoHours { get; set; }


    }
}