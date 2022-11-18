using Shared;
using Shared.DTOs;

namespace ShopApplication.LogicInterfaces;

public interface IOrderItemLogic
{
    //Task<List<OrderItem>> GetAllOrderItemsAsync();
    Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemsParametersDto parametersDto);
    Task<OrderItem> OrderProduct(OrderItemCreationDto orderToCreate);
}