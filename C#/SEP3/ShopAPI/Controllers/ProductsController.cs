using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;
using ShopApplication.LogicInterfaces;

namespace Shop.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductLogic productLogic;

    public ProductsController(IProductLogic productLogic)
    {
        this.productLogic = productLogic;
    }
    
    [HttpGet]
    public async Task<ActionResult<Product>> GetByIdAsync([FromRoute] long id) 
    {
        try
        {
            var products = await productLogic.GetByIdAsync(id);
            return Ok(products);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}