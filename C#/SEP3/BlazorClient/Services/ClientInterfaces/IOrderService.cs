using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.ClientInterfaces;

public interface IOrderService
{
    Task<Order> CreateAsync(OrderCreationDto orderToCreate);
    Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto? searchParameters);
}