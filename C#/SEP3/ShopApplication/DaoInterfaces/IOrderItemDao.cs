using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface IOrderItemDao
{
   // Task<List<OrderItem>> GetAllOrderItemsAsync();
    Task<OrderItem> OrderProduct(long id, int quantity);
    Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemsParametersDto parametersDto);
}