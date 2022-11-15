using Shared;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IProductService
{
    //Task<Product> Create(ProductCreationDto dto);
   // Task<IEnumerable<Product>> GetProducts(string? nameContains = null);
    Task<ICollection<Product>> GetAsync(string? nameContains = null);
    Task<ProductCreationDto> GetByIdAsync(long? id);
}