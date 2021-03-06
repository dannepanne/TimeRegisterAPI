using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO.CustDTO;
using TimeRegisterAPI.DTO.ProjDTO;

namespace TimeRegisterAPI.Infrastructure.DTOReturners;

public class CustomerDTOReturner : ICustomerDTOReturner
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CustomerDTOReturner(ApplicationDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public List<ProjectsListViewDTO> ReturnCustomerProjectDtos(int customerId)
    {
        var projects = _context.Projects.Where(e => e.CustomerId == customerId);

        var returnList = new List<ProjectsListViewDTO>();
        foreach (var project in projects.ToList())
        {
            var newDTO = new ProjectsListViewDTO
            {
                Id = project.Id,
                ProjectName = project.Name,
                CustomerName = _context.Customers.FirstOrDefault(x => x.Id == customerId).Name,
                EndDate = project.EndDate
            };
        }

        return returnList;
    }

    public CustomerOverviewDTO ReturnCustomerOverViewDto(int customerId)
    {
        var customer = _context.Customers.Include(p => p.Projects).FirstOrDefault(c => c.Id == customerId);
        var customerOverviewDTO = new CustomerOverviewDTO
        {
            Id = customer.Id,
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
            var customer = _context.Customers.First(p => p.Id == cust.Id);
            var model = _mapper.Map<CustomerListViewDTO>(customer);

            custDTOlist.Add(model);
        }

        return custDTOlist;
    }
}