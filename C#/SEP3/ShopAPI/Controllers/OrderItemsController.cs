using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;
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
    
    /*[HttpGet]
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
    }*/
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderItem>>> GetAsync([FromQuery] long? id)
    {
        try
        {
            SearchOrderItemsParametersDto parameters = new(id);
            IEnumerable<OrderItem> orderItems = await orderItemLogic.GetAsync(parameters);
            return Ok(orderItems);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpPost]
    public async Task<ActionResult<OrderItem>> OrderProduct(OrderItemCreationDto dto)
    {
        try
        {
            OrderItem orderItem = await orderItemLogic.OrderProduct(dto);
            return Created($"/OrderItems/{orderItem.id}", orderItem);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
    }
    
    [HttpPatch]
    public async Task<ActionResult> UpdateAsync([FromBody] OrderItemUpdateDto dto)
    {
        try
        {
            await orderItemLogic.UpdateAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    [HttpPatch("/Buy")]
    public async Task<ActionResult> BuyAsync([FromBody] OrderItemUpdateDto dto)
    {
        try
        {
            await orderItemLogic.BuyAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete("{id:long}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
    {
        try
        {
            await orderItemLogic.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{id:long}")]
    public async Task<ActionResult<OrderItemGetDto>> GetById([FromRoute] long id)
    {
        try
        {
            OrderItemGetDto result = await orderItemLogic.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("/NotBought/{username}")]
    public async Task<ActionResult<IEnumerable<OrderItem>>> GetNotBoughtOrderItems([FromRoute] string username)
    {
        try
        {
            IEnumerable<OrderItem> orderItems = await orderItemLogic.GetNotBoughtOrderItemsByUsername(username);
            return Ok(orderItems);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}