using Shared;

namespace BlazorClient.Services.ClientInterfaces;

public interface IProductService
{
    //Task<Product> Create(ProductCreationDto dto);
    Task<IEnumerable<Product>> GetProducts(string? nameContains = null);
}