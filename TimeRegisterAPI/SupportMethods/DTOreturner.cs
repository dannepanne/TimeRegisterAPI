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
    public List<ProjectOverviewDTO> ReturnProjectDtos(int customerId)
    {

        var projects = _context.Projects.Where(e => e.CustomerId == customerId);

        List<ProjectOverviewDTO> returnList = new List<ProjectOverviewDTO>();
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
        List<CustomerListViewDTO> custDTOlist = new List<CustomerListViewDTO>();
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
}
