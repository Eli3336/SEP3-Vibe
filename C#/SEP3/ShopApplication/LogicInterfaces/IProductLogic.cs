using Shared;
using Shared.DTOs;

namespace ShopApplication.LogicInterfaces;

public interface IProductLogic
{
    Task<IEnumerable<Product>> GetAsync(SearchProductParametersDto searchProductParametersDto);

    Task<object?> GetByIdAsync(long id);
}