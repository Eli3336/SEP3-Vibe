using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class ProductEfcDao : IProductDao
{
    
    private readonly TodoContext context;

    public async Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto)
    {
        IQueryable<Product> query = context.Products.Include(product => product.id).AsQueryable();
    
        if (!string.IsNullOrEmpty(searchProductsParametersDto.nameContains))
        {
            // we know username is unique, so just fetch the first
            query = query.Where(product =>
                product.name.ToLower().Equals(searchProductsParametersDto.nameContains.ToLower()));
        }
    
       
        List<Product> result = await query.ToListAsync();
        return result;    }

    public async  Task<Product?> GetByIdAsync(long id)
    {
        
        Product? found = await context.Products
            .Include(product => product.id)
            .SingleOrDefaultAsync(product => product.id == id);
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
        context.SaveChanges();    }
    
    /*
    public async Task<Product> CreateAsync(Product product)
    {
        EntityEntry<Product> added = await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return added.Entity;
    }
    */
    /*
    public async Task UpdateAsync(Product product)
    {
        context.ChangeTracker.Clear();
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }
    */
}