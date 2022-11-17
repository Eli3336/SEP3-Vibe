using Shared;

namespace HttpClients.ClientInterfaces;

public interface IProductService
{
    //Task<Product> Create(ProductCreationDto dto);
    Task<IEnumerable<Product>> GetProducts(string? nameContains = null);
}