using TimeRegisterAPI.DTO.ProjDTO;

namespace TimeRegisterAPI.Infrastructure.DTOReturners;

public interface IProjectDTOReturner
{
    public List<ProjectsListViewDTO> ReturnProjectListDto();

    public ProjectOverviewDTO ReturnProjOverviewDto(int id);
    public List<ProjectsListViewDTO> ReturnActiveProjectsDto();

    public List<ProjectsListViewDTO> ReturnFinishedProjectsDto();
}