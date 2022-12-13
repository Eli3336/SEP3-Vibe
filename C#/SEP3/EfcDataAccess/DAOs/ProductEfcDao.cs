using EfcDataAccess.FileStorage;
using Grpc.Net.Client;
using GrpcClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using Grpc.Core;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfcDataAccess.DAOs;

public class ProductEfcDao : IProductDao
{
    
    private readonly ShopContext context;
    private readonly FileContext fileContext;

    private ICategoryDao categoryDao;
    
   // private readonly GrpcChannel Channel = GrpcChannel.ForAddress("http://localhost:8843");
    private ShopGrpc.ShopGrpcClient ClientProduct;
    public ProductEfcDao(ShopContext context, ICategoryDao categoryDao, FileContext fileContext)
    {
        this.context = context;
        var grpcChannel = new Channel("localhost:8843", ChannelCredentials.Insecure);
        ClientProduct = new(grpcChannel);
        this.categoryDao = categoryDao;
        this.fileContext = fileContext;
    }

    public async Task<string> Seed()
    {
        List<Product> products = context.Products.ToList();
        for (int i = 0; i < products.Count; i++)
        {
            Product? existing = products[i];
            if (existing == null)
            {
                throw new Exception($"Product with id {products[i].id} not found");
            }
            context.Products.Remove(existing);
            await context.SaveChangesAsync();    
        }
        await context.SaveChangesAsync();

        List<string> images = fileContext.Images.ToList();

        Product toCreate1 = new Product()
        {
            id = 1,
            name = "Stella Drop Earrings",
            description = "gold-filled, Cubic Zirconia, 30mm long, handmade",
            price = 10,
            stock = 25,
            image = images[0],
            ingredients = "gold",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate1);
        await context.SaveChangesAsync();
        Product toCreate2 = new Product()
        {
            id = 2,
            name = "Allium Blue Green Sapphire",
            description = "6.5 blue green sapphire, 5.5 mm, gold",
            price = 20,
            stock = 25,
            image = images[1],
            ingredients = "gold, blue green sapphire",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate2);
        await context.SaveChangesAsync();
        Product toCreate3 = new Product()
        {
            id = 3,
            name = "5.5 Beveled Edge Matte",
            description = "BE225-18KW 18K white gold, with rhodium finish",
            price = 25,
            stock = 25,
            image = images[2],
            ingredients = "gold, rhodium",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate3);
        await context.SaveChangesAsync();


        return "Ok";
    }

    public async Task<Product> CreateAsync(Product product)
    {
        EntityEntry<Product> newProduct = await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return newProduct.Entity;
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

    public async Task<Product?> GetByIdAsync(long id)
    {
        Product? found = await context.Products
            .Include(product => product.category)
            .SingleOrDefaultAsync(product => product.id == id);
       //     .AsNoTracking().FirstOrDefaultAsync(p => p.id == id);

        return found;
    }

    public async Task UpdateAsync(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync(); 
    }

    public async  Task<Product?> GetByIdToUpdateAsync(long? id)
    {
        Product? found = await context.Products
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.id == id);

        return found;
    }
    
    public async Task<Product?> GetByIdToUpdateAsyncWithCategory(long? id)
    {
        Product? found = await context.Products
            .Include(product => product.category)
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
                Price = product.price,
                Category = new CategoryGrpc()
                {
                    Name = product.category.ToString()
                }
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return productResponse.Confirmed;
    }
}