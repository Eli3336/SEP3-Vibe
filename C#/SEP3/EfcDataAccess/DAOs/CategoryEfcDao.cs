using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class CategoryEfcDao : ICategoryDao
{
    private readonly ShopContext context;
    
    public CategoryEfcDao(ShopContext context)
    {
        this.context = context;
    }
    
    public async Task<string> Seed()
    {
        List<Category> categories = context.Categories.ToList();
        for (int i = 0; i < categories.Count; i++)
        {
            Category? existing = categories[i];
            if (existing == null)
            {
                throw new Exception($"Category with name {categories[i].name} not found");
            }
            context.Categories.Remove(existing);
            await context.SaveChangesAsync();    
        }
        await context.SaveChangesAsync();
        Category toCreate = new Category
        {
            name = "Jewelry"
        };
        await context.Categories.AddAsync(toCreate);
        await context.SaveChangesAsync();
        Category toCreate1 = new Category
        {
            name = "Clothes"
        };
        await context.Categories.AddAsync(toCreate1);
        await context.SaveChangesAsync();
        Category toCreate2 = new Category
        {
            name = "Cosmetics"
        };
        await context.Categories.AddAsync(toCreate2);
        await context.SaveChangesAsync();
        Category toCreate3 = new Category
        {
            name = "Home Decor"
        };
        await context.Categories.AddAsync(toCreate3);
        await context.SaveChangesAsync();
        return "Ok";
    }
    
    public async Task<IEnumerable<Category>> GetAsync(SearchCategoryParametersDto searchCategoryParametersDto)
    {
        IQueryable<Category> query = context.Categories.AsQueryable();
    
        if (searchCategoryParametersDto.nameContains != null)
        {
            // we know username is unique, so just fetch the first
            query = query.Where(p =>
                p.name.ToLower().Contains(searchCategoryParametersDto.nameContains.ToLower()));
        }
        
        IEnumerable<Category> result = await query.ToListAsync();
        return result;
    }

    public async Task<Category?> GetByName(string name)
    {
        Category? existing = await context.Categories.FirstOrDefaultAsync(c => c.name == name);
        return existing;
    }
}