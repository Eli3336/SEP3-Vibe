using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface IProductDao
{
    /* public Task<List<Product>> GetProductsAsync();
     
     Task<Product?> GetByNameAsync(string name);
 */
    Task<Product> CreateAsync(Product product);
    Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto);

     Task<Product?> GetSearchAsync(string? search);

     Task<Product?> GetByIdAsync(long id);
     Task DeleteAsync(long id);
     Task AdminUpdateAsync(Product product);

     Task<Product?> GetByIdToUpdateAsync(long? id);
     
     Task<String> CreateAdminOrderAsync(Product product);

}