using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface IOrderItemDao
{
   // Task<List<OrderItem>> GetAllOrderItemsAsync();
    Task<OrderItem> OrderProduct(OrderItem orderItem);
    Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemsParametersDto parametersDto);
    Task UpdateAsync(OrderItem orderItem);
    Task BuyAsync(OrderItem orderItem);
    Task<OrderItem?> GetByIdAsync(long id);
    Task DeleteAsync(long id);

    Task<OrderItem?> GetByIdToUpdateAsync(long id);

    Task<IEnumerable<OrderItem>> GetNotBoughtOrderItemsAsyncByUsername(string username);
}