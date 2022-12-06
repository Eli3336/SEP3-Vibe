using Shared;
using Shared.DTOs;

namespace ShopApplication.LogicInterfaces;

public interface IProductLogic
{
   Task<Product> CreateAsync(ProductCreationDto productToCreate);
    Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto);
    Task<ProductCreationDto> GetByIdAsync(long id);
    Task<IEnumerable<Product>> GetSearchAsync(string search);

    
    Task DeleteAsync(long id);
    Task AdminUpdateAsync(ProductAdminUpdateDto product);

}