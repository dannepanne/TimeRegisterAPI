using TimeRegisterAPI.DTO.TimeDTO;

namespace TimeRegisterAPI.Infrastructure.DTOReturners;

public interface ITimeRegDTOReturner
{
    public List<TimeReportListViewDTO> ReturnTimeReportListViewDtos();
    public TimeReportOverviewDTO ReturnTimeReportOverviewDto(int id);
    public List<TimeReportListViewDTO> ReturnTimeReportListViewProcessedDtos();
    public List<TimeReportListViewDTO> ReturnTimeReportListViewNotProcessedDtos();
    public List<TimeReportInvoiceDTO> TimeRegInvoiceReturner();

}