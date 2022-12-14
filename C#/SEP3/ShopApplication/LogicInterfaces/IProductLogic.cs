using Shared;
using Shared.DTOs;

namespace ShopApplication.LogicInterfaces;

public interface IProductLogic
{
   Task<Product> CreateAsync(ProductCreationDto productToCreate);
    Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto);
    Task<Product> GetByIdAsync(long id);
    Task<IEnumerable<Product>> GetSearchAsync(string search);

    Task UpdateAsync(ProductUpdateDto dto);
    Task DeleteAsync(long id);
    Task AdminUpdateAsync(ProductAdminUpdateDto product);

    Task<String> CreateAdminOrderAsync(Product product);
    Task<string> Seed();
}