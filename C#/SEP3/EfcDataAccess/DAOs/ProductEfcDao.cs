using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class ProductEfcDao : IProductDao
{
    
    private readonly ShopContext context;
    public ProductEfcDao(ShopContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto)
    {
        IQueryable<Product> query = context.Products.AsQueryable();
    
        if (searchProductsParametersDto.nameContains != null)
        {
            // we know username is unique, so just fetch the first
            query = query.Where(p =>
                p.name.ToLower().Contains(searchProductsParametersDto.nameContains.ToLower()));
        }
        
        IEnumerable<Product> result = await query.ToListAsync();
        return result;
    }

    public async  Task<Product?> GetByIdAsync(long? id)
    {
        Product? found = await context.Products.AsNoTracking().
        FirstOrDefaultAsync(p => p.id == id);

        return found;
    }

    public async Task DeleteAsync(long id)
    {
        Product? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"Product with id {id} not found");
        }

        context.Products.Remove(existing);
        await context.SaveChangesAsync();    
    }

    public async Task AdminUpdateAsync(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();    }

    /*
    public async Task<Product> CreateAsync(Product product)
    {
        EntityEntry<Product> added = await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return added.Entity;
    }
    */
   
}