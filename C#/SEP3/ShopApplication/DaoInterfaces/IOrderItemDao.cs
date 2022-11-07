using Shared;

namespace ShopApplication.DaoInterfaces;

public interface IOrderItemDao
{
    Task<List<OrderItem>> GetAllOrderItemsAsync();
    Task<OrderItem> OrderProduct(long id, int quantity);
}