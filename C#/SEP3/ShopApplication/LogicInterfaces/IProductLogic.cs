using Shared;
using Shared.DTOs;

namespace ShopApplication.LogicInterfaces;

public interface IProductLogic
{
   /* Task<Product?> GetByNameAsync(string name);    
    Task<List<Product>> GetProductsAsync();
*/
    Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto);
}