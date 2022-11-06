using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface IProductDao
{
    Task<IEnumerable<Product>> GetAsync(SearchProductParametersDto searchParameters);

    Task<Product> GetByIdAsync(long id);
}