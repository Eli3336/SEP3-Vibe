using Shared;
using Shared.DTOs;

namespace ShopApplication.LogicInterfaces;

public interface IProductLogic
{
    Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto);
    Task<ProductCreationDto> GetByIdAsync(long id);
    
    Task DeleteAsync(int id);
}