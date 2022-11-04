using Shared;

namespace ShopApplication.DaoInterfaces;

public interface IProductDao
{
    
  
    
    public Task<List<Product>> GetProductsAsync();
    
    Task<Product?> GetByNameAsync(string name);
    
    
}