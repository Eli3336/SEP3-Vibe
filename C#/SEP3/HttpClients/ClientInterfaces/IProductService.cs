using Shared;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IProductService
{
    //Task<Product> Create(ProductCreationDto dto);
    Task<ICollection<Product>> GetAsync(string? nameContains=null);
    Task<ProductCreationDto> GetByIdAsync(long? id);
}