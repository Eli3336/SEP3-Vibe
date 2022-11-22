using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.ClientInterfaces;

public interface IOrderItemService
{
    Task<OrderItem> OrderProduct(OrderItemCreationDto dto);
    Task<IEnumerable<OrderItem>> GetOrderItem(string? nameContains = null);
    Task DeleteAsync(long id);

}