using Shared;

namespace ShopApplication.LogicInterfaces;

public interface IProductLogic
{
    Task<Product?> GetByNameAsync(string name);    
    Task<List<Product>> GetProductsAsync();
}