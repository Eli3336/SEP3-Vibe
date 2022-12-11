using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;
using ShopApplication.LogicInterfaces;

namespace Shop.Controllers;



[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryLogic categoryLogic;

    public CategoriesController(ICategoryLogic categoryLogic)
    {
        this.categoryLogic = categoryLogic;
    }
    
    [HttpPatch]
    public async Task<ActionResult> UpdateEverything()
    {
        try
        {
            string response = await categoryLogic.Seed();
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    

     [HttpGet]
     public async Task<ActionResult<IEnumerable<Category>>> GetAsync([FromQuery] string? name)
     {
         try
         {
             SearchCategoryParametersDto parameters = new(name);
             IEnumerable<Category> products = await categoryLogic.GetAsync(parameters);
             return Ok(products);
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             return StatusCode(500, e.Message);
         }
     }
}
