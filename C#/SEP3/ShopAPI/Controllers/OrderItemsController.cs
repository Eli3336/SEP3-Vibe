using Microsoft.AspNetCore.Mvc;
using Shared;
using ShopApplication.LogicInterfaces;

namespace Shop.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderItemsController : ControllerBase
{
    private readonly IOrderItemLogic orderItemLogic;

    public OrderItemsController(IOrderItemLogic orderItemLogic)
    {
        this.orderItemLogic = orderItemLogic;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<OrderItem>>> GetAllOrderItemsAsync()
    {
        try
        {
            List<OrderItem> orderItems = await orderItemLogic.GetAllOrderItemsAsync();
            return Ok(orderItems);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<OrderItem>> OrderProduct(long id, int quantity)
    {
        try
        {
            OrderItem orderItem = await orderItemLogic.OrderProduct(id, quantity);
            return Created($"/orderItems/{orderItem.product.id}", orderItem);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
    }
}