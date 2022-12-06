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


  /*  public async Task<Product> CreateAsync(Product product)
    {
       // EntityEntry<Product> newProduct = await context.CreateProduct(product);
        await context.SaveChangesAsync();
      //  return newProduct.Entity;
        //it can't create product bcs unique constraint on category name
    }\
    */

    public async Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto)
    {
        IQueryable<Product> query = context.Products.AsQueryable();
    
        if (searchProductsParametersDto.nameContains != null)
        {
            query = query.Where(p =>
                p.name.ToLower().Contains(searchProductsParametersDto.nameContains.ToLower()));
        }
        
        IEnumerable<Product> result = await query.ToListAsync();
        return result;
    }

    public async  Task<Product?> GetByIdAsync(long? id)
    {
        Product? found = await context.Products.FindAsync(id);
       //     .AsNoTracking().FirstOrDefaultAsync(p => p.id == id);

        return found;
    }
    
    public async  Task<Product?> GetByIdToUpdateAsync(long? id)
    {
        Product? found = await context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.id == id);

        return found;
    }

    public async Task<Product?> GetSearchAsync(string? search)
    {
        Product?  existing = await context.Products.FirstOrDefaultAsync(p =>
            p.name.ToLower().Equals(search.ToLower())
        );
        return existing;
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