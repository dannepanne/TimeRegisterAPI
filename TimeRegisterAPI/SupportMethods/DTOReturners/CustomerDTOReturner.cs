using Microsoft.EntityFrameworkCore;
using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO.CustDTO;
using TimeRegisterAPI.DTO.ProjDTO;

namespace TimeRegisterAPI.SupportMethods.DTOReturners;

public class CustomerDTOReturner : ICustomerDTOReturner
{
    private readonly IMathHelpers _mathHelpers;
    private readonly ApplicationDbContext _context;

    public CustomerDTOReturner(ApplicationDbContext context, IMathHelpers mathHelpers)
    {
        _mathHelpers = mathHelpers;
        _context = context;
    }
    public List<ProjectsListViewDTO> ReturnCustomerProjectDtos(int customerId)
    {

        var projects = _context.Projects.Where(e => e.CustomerId == customerId);

        var returnList = new List<ProjectsListViewDTO>();
        foreach (var project in projects.ToList())
        {
            ProjectsListViewDTO newDTO = new ProjectsListViewDTO
            {
                ProjectName = project.Name,
                CustomerName = _context.Customers.FirstOrDefault(x=>x.Id == customerId).Name,
                EndDate = project.EndDate

            };
        }
        return returnList;

    }

    public CustomerOverviewDTO ReturnCustomerOverViewDto(int customerId)
    {
        var customer = _context.Customers.Include(p=>p.Projects).FirstOrDefault(c => c.Id == customerId);
        CustomerOverviewDTO customerOverviewDTO = new CustomerOverviewDTO
        {
            CustomerName = customer.Name,
            Projects = ReturnCustomerProjectDtos(customerId)

        };
        return customerOverviewDTO;
    }

    

    public List<CustomerListViewDTO> ReturnCustomerListViewDtos()
    {
        var custDTOlist = new List<CustomerListViewDTO>();
        foreach (var cust in _context.Customers.ToList())
        {
            CustomerListViewDTO newDto = new CustomerListViewDTO
            {
                Id = cust.Id,
                Name = cust.Name
            };
                custDTOlist.Add(newDto);
        }

        return custDTOlist;
    }


}
