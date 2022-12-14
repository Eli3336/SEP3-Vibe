using Shared;
using Shared.DTOs;

namespace ShopApplication.LogicInterfaces;

public interface IOrderItemLogic
{
    //Task<List<OrderItem>> GetAllOrderItemsAsync();
    Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemsParametersDto parametersDto);
    Task<OrderItem> OrderProduct(OrderItemCreationDto dto);
    Task UpdateAsync(OrderItemUpdateDto orderItem);
    Task BuyAsync(OrderItemUpdateDto dto);
    Task DeleteAsync(long id);
    Task<OrderItemGetWithProductIdDto> GetByIdAsync(long id);
    Task<IEnumerable<OrderItem>> GetNotBoughtOrderItemsByUsername(string username);
}