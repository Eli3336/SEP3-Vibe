using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface ICategoryDao
{
    Task<IEnumerable<Category>> GetAsync(SearchCategoryParametersDto searchCategoryParametersDto);
    Task<Category?> GetByName(string name);
    Task<string> Seed();
}