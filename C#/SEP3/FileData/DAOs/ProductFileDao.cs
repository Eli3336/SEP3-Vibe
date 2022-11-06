using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace FileData.DAOs;

public class ProductFileDao : IProductDao
{
    private readonly FileContext context;

    public ProductFileDao(FileContext fileContext)
    {
        context = fileContext;
    }

    public Task<IEnumerable<Product>> GetAsync(SearchProductParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetByIdAsync(long id)
    {
        Product? existing = context.Products.FirstOrDefault(p => p.id == id);
        return Task.FromResult(existing);
    }
}