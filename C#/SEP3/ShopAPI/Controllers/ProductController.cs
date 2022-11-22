using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;
using ShopApplication.LogicInterfaces;

namespace Shop.Controllers;



[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductLogic productLogic;

    public ProductController(IProductLogic productLogic)
    {
        this.productLogic = productLogic;
    }

    /*   [HttpPost]
       public async Task<ActionResult<Product>> CreateAsync(Pro dto)
       {
           try
           {
               Product product = await productLogic.CreateAsync(dto);
               return Created($"/products/{product.Id}", product);
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
               return StatusCode(500, e.Message);
           }
       }
       */

     [HttpGet]
     public async Task<ActionResult<IEnumerable<Product>>> GetAsync([FromQuery] string? name)
     {
         try
         {
             SearchProductsParametersDto parameters = new(name);
             IEnumerable<Product> products = await productLogic.GetAsync(parameters);
             return Ok(products);
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             return StatusCode(500, e.Message);
         }
     }
     
     [HttpGet("{id:long}")]
     public async Task<ActionResult<ProductCreationDto>> GetById([FromRoute] long id)
     {
         try
         {
             ProductCreationDto result = await productLogic.GetByIdAsync(id);
             return Ok(result);
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             return StatusCode(500, e.Message);
         }
     }



}
