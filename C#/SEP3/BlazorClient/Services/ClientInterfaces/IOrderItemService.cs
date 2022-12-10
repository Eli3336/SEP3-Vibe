using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.ClientInterfaces;

public interface IOrderItemService
{
    Task<OrderItem> OrderProduct(OrderItemCreationDto dto);
    Task<IEnumerable<OrderItem>> GetOrderItem(string? nameContains = null);
    Task DeleteAsync(long id);
    Task UpdateAsync(OrderItemUpdateDto orderItem);
    Task<OrderItemCreationDto> GetByIdAsync(long id);

    Task<List<OrderItem>> GetAll();

    Task<IEnumerable<OrderItem>> GetNotBoughtOrderItems();

}