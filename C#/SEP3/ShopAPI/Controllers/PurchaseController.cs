using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;
using ShopApplication.LogicInterfaces;

namespace Shop.Controllers;



[ApiController]
[Route("[controller]")]

public class PurchaseController
{
    
    private readonly IPurchaseLogic purchaseLogic;

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAsync([FromQuery] string? name)
    {
        try
        {
            SearchProductsParametersDto parameters = new(name);
            IEnumerable<Product> products = await purchaseLogic.GetAsync(parameters);
            return Ok(products);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}