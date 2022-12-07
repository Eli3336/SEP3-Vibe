using Grpc.Net.Client;
using GrpcClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class ProductEfcDao : IProductDao
{
    
    private readonly ShopContext context;
    
    private readonly GrpcChannel Channel = GrpcChannel.ForAddress("http://localhost:6566");
    private ShopGrpc.ShopGrpcClient ClientProduct;
    public ProductEfcDao(ShopContext context)
    {
        this.context = context;
        ClientProduct = new(Channel);

    }


    public async Task<Product> CreateAsync(Product product)
    {
        EntityEntry<Product> newProduct = await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return newProduct.Entity;
        //it can't create product bcs unique constraint on category name
    }
    

    public async Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto)
    {
        IQueryable<Product> query = context.Products.Include(product => product.category).AsQueryable();
    
        if (searchProductsParametersDto.nameContains != null)
        {
            query = query.Where(p =>
                p.name.ToLower().Contains(searchProductsParametersDto.nameContains.ToLower()));
        }
        
        IEnumerable<Product> result = await query.ToListAsync();
        return result;
    }

    public async  Task<Product?> GetByIdAsync(long id)
    {
        Product? found = await context.Products.Include(product => product.category).FirstAsync(product => product.id == id);
       //     .AsNoTracking().FirstOrDefaultAsync(p => p.id == id);

        return found;
    }
    
    public async  Task<Product?> GetByIdToUpdateAsync(long? id)
    {
        Product? found = await context.Products
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.id == id);

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
        ProductResponse productGrpc = await ClientProduct.EditProductAsync(new ProductGrpc()
        {
            Id = product.id,
            Name = product.name,
            Description = product.description,
            Category = new CategoryGrpc()
            {
                Name = product.category.ToString()
            },
            Price = product.price
            
        });
        
        
        context.Products.Update(product);
        await context.SaveChangesAsync();    
    }

    public async Task<String> CreateAdminOrderAsync(Product product)
    {
        ProductResponse productResponse = new ProductResponse();
        try
        {
            productResponse = await ClientProduct.OrderProductAsync(new ProductGrpc()
            {
                Id = product.id,
                Name = product.name,
                Description = product.description,
                Category = new CategoryGrpc()
                {
                    Name = product.category.ToString()
                },
                Price = product.price
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return "" + productResponse;
    }
}