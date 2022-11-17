using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;
using ShopApplication.LogicInterfaces;

namespace Shop.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerLogic customerLogic;

    public CustomersController(ICustomerLogic customerLogic)
    {
        this.customerLogic = customerLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Customer>> CreateAsync(CustomerCreationDto dto)
    {
        try
        {
            Customer customer = await customerLogic.CreateAsync(dto);
            return Created($"/customers/{customer.Id}", customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAsync([FromQuery] string? username)
    {
        try
        {
            SearchCustomerParametersDto parameters = new(username);
            IEnumerable<Customer> users = await customerLogic.GetAsync(parameters);
            return Ok(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}