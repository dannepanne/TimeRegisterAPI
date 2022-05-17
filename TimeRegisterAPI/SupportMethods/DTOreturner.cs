using Microsoft.Data.SqlClient;
using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO;
using TimeRegisterAPI.DTO.CustDTO;
using TimeRegisterAPI.DTO.ProjDTO;
using TimeRegisterAPI.DTO.TimeDTO;

namespace TimeRegisterAPI.SupportMethods;

public class DTOreturner : IDTOreturner
{
    private readonly IMathHelpers _mathHelpers;
    private readonly ApplicationDbContext _context;

    public DTOreturner(ApplicationDbContext context, IMathHelpers mathHelpers)
    {
        _mathHelpers = mathHelpers;
        _context = context;
    }
    public List<ProjectOverviewDTO> ReturnCustomerProjectDtos(int customerId)
    {

        var projects = _context.Projects.Where(e => e.CustomerId == customerId);

        var returnList = new List<ProjectOverviewDTO>();
        foreach (var project in projects)
        {
            ProjectOverviewDTO newDTO = new ProjectOverviewDTO()
            {
                ProjectName = project.Name,
                Description = project.Description,
                TimeSpentSoFar = _mathHelpers.TimeSpentSoFar(project)

            };
        }
        return returnList;

    }

    public CustomerOverviewDTO ReturnCustomerOverViewDto(int customerId)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
        CustomerOverviewDTO customerOverviewDTO = new CustomerOverviewDTO()
        {
            CustomerName = customer.Name,
            NoProjects = customer.Projects.Count()

        };
        return customerOverviewDTO;
    }

    public TimeReportDTO ReturnTimeReportDto(int timereportId)
    {
        var timereport = _context.TimeReports.FirstOrDefault(e => e.Id == timereportId);
        var projname = _context.Projects.FirstOrDefault(n => n.Id == timereport.ProjectId).Name;
        TimeReportDTO reportDto = new TimeReportDTO()
        {
            ProjectName = projname,
            NoHours = timereport.NoHours,
            Sum = timereport.Sum,
        };

        return reportDto;

    }

    public List<CustomerListViewDTO> ReturnCustomerListViewDtos()
    {
        var custDTOlist = new List<CustomerListViewDTO>();
        foreach (var cust in _context.Customers)
        {
            CustomerListViewDTO newDto = new CustomerListViewDTO()
            {
                Id = cust.Id,
                Name = cust.Name
            };
                custDTOlist.Add(newDto);
        }

        return custDTOlist;
    }


    public List<ProjectsListViewDTO> ReturnProjectListDto()
    {
        var projListDto = new List<ProjectsListViewDTO>();
        foreach (var project in _context.Projects)
        {
            ProjectsListViewDTO newDto = new ProjectsListViewDTO
            {
                ProjectName = project.Name,
                CustomerName = _context.Customers.FirstOrDefault(c => c.Id == project.CustomerId).Name,
            };
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
}
