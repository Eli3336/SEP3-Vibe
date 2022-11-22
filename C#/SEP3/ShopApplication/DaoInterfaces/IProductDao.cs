using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface IProductDao
{
    
  
    
   /* public Task<List<Product>> GetProductsAsync();
    
    Task<Product?> GetByNameAsync(string name);
*/

     Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto);
     Task<Product?> GetByIdAsync(long id);
     
     Task DeleteAsync(long id);

}