using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;
using ShopApplication.LogicInterfaces;

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
    public async Task<ActionResult<Order>> CreateAsync(OrderCreationDto dto)
    {
        try
        {
            Order order = await orderLogic.CreateAsync(dto);
            return Created($"/orders/{order.Id}", order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAsync([FromQuery] long? id)
    {
        try
        {
            SearchOrderParametersDto parameters = new(id);
            IEnumerable<Order> orders = await orderLogic.GetAsync(parameters);
            return Ok(orders);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}