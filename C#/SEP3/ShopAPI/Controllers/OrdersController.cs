using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController :ControllerBase
{
    private readonly IOrderLogic orderLogic;

    public OrdersController(IOrderLogic orderLogic)
    {
        this.orderLogic = orderLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Order>> CreateAsync(CustomerCreationDto dto)
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