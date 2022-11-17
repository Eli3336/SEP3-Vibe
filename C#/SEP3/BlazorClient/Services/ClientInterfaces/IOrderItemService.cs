using Shared;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IOrderItemService
{
    Task<OrderItem> OrderProduct(OrderItemCreationDto dto);
    Task<IEnumerable<OrderItem>> GetOrderItem(string? nameContains = null);
}