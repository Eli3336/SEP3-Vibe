using Shared;
using Shared.DTOs;

namespace ShopApplication.LogicInterfaces;

public interface ICategoryLogic
{
    Task<string> Seed();
    Task<IEnumerable<Category>> GetAsync(SearchCategoryParametersDto searchProductsParametersDto);
}