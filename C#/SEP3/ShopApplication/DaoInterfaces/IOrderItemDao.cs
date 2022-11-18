using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface IOrderItemDao
{
   // Task<List<OrderItem>> GetAllOrderItemsAsync();
    Task<OrderItem> OrderProduct(OrderItem orderItem);
    Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemsParametersDto parametersDto);
}