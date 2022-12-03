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
