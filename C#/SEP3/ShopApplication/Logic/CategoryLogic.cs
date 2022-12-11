using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using ShopApplication.LogicInterfaces;

namespace ShopApplication.Logic;

public class CategoryLogic : ICategoryLogic
{
    private readonly ICategoryDao categoryDao;

    public CategoryLogic(ICategoryDao categoryDao)
    {
        this.categoryDao = categoryDao;
    }
    
    public Task<IEnumerable<Category>> GetAsync(SearchCategoryParametersDto searchCategoryParametersDto)
    {
        return categoryDao.GetAsync(searchCategoryParametersDto);
    }

    public async Task<string> Seed()
    {
        return await categoryDao.Seed();
    }
}