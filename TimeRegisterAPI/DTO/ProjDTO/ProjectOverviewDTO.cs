namespace TimeRegisterAPI.DTO.ProjDTO
{
    public class ProjectOverviewDTO
    {
        public string ProjectName { get; set; }
        public int? TimeSpentSoFar { get; set; }
        public int? TotalSumSoFar { get; set; }
        public int PricePerHour { get; set; }
        public string Description { get; set; }
        
        public DateTime EndDate { get; set; }
        

    }
}
