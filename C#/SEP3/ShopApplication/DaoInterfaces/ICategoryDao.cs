using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface ICategoryDao
{
    Task<IEnumerable<Category>> GetAsync(SearchCategoryParametersDto searchCategoryParametersDto);
}