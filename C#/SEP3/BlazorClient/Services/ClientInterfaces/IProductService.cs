using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.ClientInterfaces;

public interface IProductService
{
    //Task<Product> Create(ProductCreationDto dto);
    Task<ICollection<Product>> GetAsync(string? nameContains=null);
    Task<ICollection<ProductDto>> GetSearchAsync(string? search);

    
    Task<ProductCreationDto> GetByIdAsync(long? id);
    Task<ProductDto> GetDtoByIdAsync(long? id);
    Task<ProductAdminUpdateDto> GetUpdateDtoByIdAsync(long? id);
    Task SaveEditAsync(long id, string? name, string? description, double? price, string? image, string? ingredients, string? categoryName);

    Task DeleteAsync(long id);

    Task<Product> GetProductById(long id);

}