using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using ShopApplication.LogicInterfaces;

namespace ShopApplication.Logic;

public class ProductLogic : IProductLogic
{
    private readonly IProductDao productDao;
    
    public ProductLogic(IProductDao userDao)
    {
        this.productDao = productDao;
    }
    
    public Task<IEnumerable<Product>> GetAsync(SearchProductParametersDto searchParameters)
    {
        return productDao.GetAsync(searchParameters);
    }

    public Task<object?> GetByIdAsync(long id)
    {
        object? product = productDao.GetByIdAsync(id);
        return Task.FromResult(product);
    }
    
}