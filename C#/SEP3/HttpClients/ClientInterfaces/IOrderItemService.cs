using Shared;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IOrderItemService
{
    //Task<OrderItem> OrderProduct(long id, int quantity);
    Task<IEnumerable<OrderItem>> GetOrderItem(string? nameContains = null);
}