using Shared;

namespace ShopApplication.LogicInterfaces;

public interface IOrderItemLogic
{
    Task<List<OrderItem>> GetAllOrderItemsAsync();
    Task<OrderItem> OrderProduct(long id,int quantity);
}