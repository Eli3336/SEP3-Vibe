using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers;

public class ProductController
{
    
    
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
    
    
       /* [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAsync([FromQuery] string? name)
        {
            try
            {
                SearchProductParametersDto parameters = new(name);
                IEnumerable<Product> products = await productLogic.GetAsync(parameters);
                return Ok(products);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        */
    
    
        [HttpGet]
        public async Task<ActionResult<List<string>>> GetAllPostsAsync()
        {
            try
            {
                List<string> products = await productLogic.GetAllPostsAsync();
                return Ok(products);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}