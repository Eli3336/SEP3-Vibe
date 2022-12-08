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
    
    public ReceiptController(IReceiptLogic receiptLogic)
    {
        this.receiptLogic = receiptLogic;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Receipt>>> GetAsync([FromQuery] long? id)
    {
        try
        {
            SearchReceiptParametersDto parameters = new(id);
            IEnumerable<Receipt> receipts = await receiptLogic.GetAsync(parameters);
            return Ok(receipts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<ReceiptGetDto>> GetById([FromRoute] long id)
    {
        try
        {
            ReceiptGetDto result = await receiptLogic.GetByIdAsync(id);
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
            return Created($"/Receipt/{receipt.id}", receipt);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
    }
   
}