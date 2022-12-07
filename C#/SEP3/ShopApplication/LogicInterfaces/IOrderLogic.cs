using Shared;
using Shared.DTOs;

namespace ShopApplication.LogicInterfaces;

public interface IOrderLogic
{
    Task<Order> CreateAsync(OrderCreationDto orderToCreate);
    Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto? searchParameters);
    Task<OrderGetDto> GetByIdAsync(long id);
}