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
}