using TimeRegisterAPI.Data;

namespace TimeRegisterAPI.DTO.TimeDTO
{
    public class TimeReportInvoiceDTO
    {
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public List<TimeReport> TimeReports { get; set; } = new List<TimeReport>();
        public int InvoiceSum { get; set; }
    }
}
