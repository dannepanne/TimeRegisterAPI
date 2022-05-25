using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO.ProjDTO;
using TimeRegisterAPI.SupportMethods;

namespace TimeRegisterAPI.Infrastructure.DTOReturners
{
    public class ProjectDTOReturner : IProjectDTOReturner
    {
        private readonly ApplicationDbContext _context;
        private readonly IMathHelpers _mathHelpers;

        public ProjectDTOReturner(ApplicationDbContext context, IMathHelpers mathHelpers)
        {
            _context = context;
            _mathHelpers = mathHelpers;
        }

        public List<ProjectsListViewDTO> ReturnProjectListDto()
        {
            var projListDto = new List<ProjectsListViewDTO>();
            foreach (var project in _context.Projects.ToList())
            {
                ProjectsListViewDTO newDto = new ProjectsListViewDTO
                {
                    ProjectName = project.Name,
                    CustomerName = _context.Customers.FirstOrDefault(c => c.Id == project.CustomerId).Name,
                    EndDate = project.EndDate
                };
                projListDto.Add(newDto);
            }
            var orderedlist = projListDto.OrderBy(x => x.CustomerName).ToList();
            return orderedlist;
        }

        public ProjectOverviewDTO ReturnProjOverviewDto(int id)
        {
            var proj = _context.Projects.FirstOrDefault(x => x.Id == id);
            var projOverview = new ProjectOverviewDTO()
            {
                ProjectName = proj.Name,
                Description = proj.Description,
                PricePerHour = proj.PricePerHour,
                TimeSpentSoFar = _mathHelpers.TimeSpentSoFar(proj),
                TotalSumSoFar = _mathHelpers.TimeSpentSoFar(proj) * proj.PricePerHour
            };
            return projOverview;
        }

        public List<ProjectsListViewDTO> ReturnActiveProjectsDto()
        {
            var returnList = new List<ProjectsListViewDTO>();
            foreach (var project in _context.Projects.ToList())
            {
                if (project.Active == true)
                {
                    var projOverview = new ProjectsListViewDTO()
                    {
                        ProjectName = project.Name,
                        CustomerName = _context.Customers.FirstOrDefault(c => c.Id == project.CustomerId).Name,
                        EndDate = project.EndDate

                    };
                    returnList.Add(projOverview);
                }
                
            }
            
            return returnList;
        }

        public List<ProjectsListViewDTO> ReturnFinishedProjectsDto()
        {
            var returnList = new List<ProjectsListViewDTO>();
            foreach (var project in _context.Projects.ToList())
            {
                if (project.Active == false)
                {
                    var projOverview = new ProjectsListViewDTO()
                    {
                        ProjectName = project.Name,
                        CustomerName = _context.Customers.FirstOrDefault(c => c.Id == project.CustomerId).Name,
                        EndDate = project.EndDate
                    };
                    returnList.Add(projOverview);
                }

            }

            return returnList;
        }
    }
}
