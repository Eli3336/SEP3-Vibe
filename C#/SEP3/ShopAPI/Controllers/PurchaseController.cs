using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;
using ShopApplication.LogicInterfaces;

namespace Shop.Controllers;



[ApiController]
[Route("[controller]")]

public class PurchaseController : ControllerBase
{
    
    private readonly IPurchaseLogic purchaseLogic;

    [HttpGet("{id:long}")]
    public async Task<ActionResult<PurchaseCreationDto>> GetById([FromRoute] long id)
    {
        try
        {
            PurchaseCreationDto result = await purchaseLogic.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Purchase>> CreateAsync(PurchaseCreationDto dto)
    {
        try
        {
            Purchase purchase = await purchaseLogic.CreateAsync(dto);
            return Created($"/OrderItems/{purchase.userId}", purchase.orderItems);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
    }
   
}