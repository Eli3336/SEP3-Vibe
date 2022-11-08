using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface IProductDao
{
    
  
    
   /* public Task<List<Product>> GetProductsAsync();
    
    Task<Product?> GetByNameAsync(string name);
*/

     Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto);
     Task<IEnumerable<Product>> GetProductById(long? id);


}