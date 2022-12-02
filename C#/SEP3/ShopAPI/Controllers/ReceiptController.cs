using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;
using ShopApplication.LogicInterfaces;

namespace Shop.Controllers;



[ApiController]
[Route("[controller]")]

public class ReceiptController : ControllerBase
{
    
    private readonly IReceiptLogic receiptLogic;

    [HttpGet("{id:long}")]
    public async Task<ActionResult<ReceiptCreationDto>> GetById([FromRoute] long id)
    {
        try
        {
            ReceiptCreationDto result = await receiptLogic.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Receipt>> CreateAsync(ReceiptCreationDto dto)
    {
        try
        {
            Receipt receipt = await receiptLogic.CreateAsync(dto);
            return Created($"/OrderItems/{receipt.id}", receipt.order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
    }
   
}