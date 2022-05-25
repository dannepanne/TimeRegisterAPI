using TimeRegisterAPI.DTO.TimeDTO;

namespace TimeRegisterAPI.SupportMethods.DTOReturners
{
    public interface ITimeRegDTOReturner
    {
        public List<TimeReportListViewDTO> ReturnTimeReportListViewDtos();
        public TimeReportOverviewDTO ReturnTimeReportOverviewDto(int id);
        public List<TimeReportListViewDTO> ReturnTimeReportListViewProcessedDtos();
        public List<TimeReportListViewDTO> ReturnTimeReportListViewNotProcessedDtos();
    }
}