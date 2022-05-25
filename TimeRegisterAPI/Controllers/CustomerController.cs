using Microsoft.AspNetCore.Mvc;
using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO.CustDTO;
using TimeRegisterAPI.Infrastructure.DTOReturners;
using TimeRegisterAPI.SupportMethods;

namespace TimeRegisterAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerDTOReturner _dtoReturner;
    private readonly IDBErrorHandlers _errorHandlers;
    private readonly IDbObjectMethods _objectMethods;

    public CustomerController(ICustomerDTOReturner dtoReturner, IDbObjectMethods objectMethods,
        IDBErrorHandlers errorHandlers)
    {
        _errorHandlers = errorHandlers;
        _objectMethods = objectMethods;
        _dtoReturner = dtoReturner;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_dtoReturner.ReturnCustomerListViewDtos());
    }


    [HttpGet]
    [Route("{id}")]
    public IActionResult GetOne(int id)
    {
        if (_errorHandlers.CustomerIdExists(id) == false)
            return NotFound("Id does not exist");
        var customer = _dtoReturner.ReturnCustomerOverViewDto(id);
        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(int id, UpdateCustomerDTO thisCust)
    {
        if (_objectMethods.UpdateCustomer(id, thisCust) == false) return NotFound();
        _objectMethods.UpdateCustomer(id, thisCust);
        return NoContent();
    }

    [HttpPost]
    public IActionResult Create(CreateCustomerDTO newcust)
    {
        var cust = new Customer
        {
            Name = newcust.Name,
            Projects = new List<Project>()
        };
        _objectMethods.SaveNewCustomer(cust);

        var customerOverviewDto = new CustomerOverviewDTO
        {
            CustomerName = newcust.Name,
            Projects = _dtoReturner.ReturnCustomerProjectDtos(newcust.Id)
        };
        return CreatedAtAction(nameof(GetOne), new { id = cust.Id }, customerOverviewDto);
    }
}