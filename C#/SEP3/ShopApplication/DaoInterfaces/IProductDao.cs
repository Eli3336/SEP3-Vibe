using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface IProductDao
{
    
  
    
   /* public Task<List<Product>> GetProductsAsync();
    
    Task<Product?> GetByNameAsync(string name);
*/

    public Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto);


}