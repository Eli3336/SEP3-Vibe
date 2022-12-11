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

    [HttpPatch("/Refresh")]
    public async Task<ActionResult> UpdateEverything()
    {
        try
        {
            string response = await productLogic.Seed();
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
       [HttpPost]
       public async Task<ActionResult<Product>> CreateAsync(ProductCreationDto dto)
       {
           try
           {
               Product product = await productLogic.CreateAsync(dto);
               return Created($"/products/{product.id}", product);
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
               return StatusCode(500, e.Message);
           }
       }
       
    

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
     [HttpGet("{search}")]
     public async Task<ActionResult<IEnumerable<Product>>> GetSearch([FromRoute] string search)
     {
         try
         {
             SearchProductsParametersDto parameters = new(search);
             IEnumerable<Product> products = await productLogic.GetAsync(parameters);
             return Ok(products);
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             return StatusCode(500, e.Message);
         }
     }
     
     [HttpDelete("{id:int}")]
     public async Task<ActionResult> DeleteAsync([FromRoute] int id)
     {
         try
         {
             await productLogic.DeleteAsync(id);
             return Ok();
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             return StatusCode(500, e.Message);
         }
     }
     
     [HttpPatch]
     public async Task<ActionResult> AdminUpdateAsync([FromBody] ProductAdminUpdateDto dto)
     {
         try
         {
             await productLogic.AdminUpdateAsync(dto);
             return Ok();
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             return StatusCode(500, e.Message);
         }
     }
    
     [HttpPost("/OrderAdminProduct")]
     public async Task<ActionResult<String>> CreateAdminOrderAsync(Product product)
     {
         try
         {
             String response = await productLogic.CreateAdminOrderAsync(product);
             return Created("Something: ", response);
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             return StatusCode(500, e.Message);
         }
     }

}
