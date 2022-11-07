using Shared;
using ShopApplication.LogicInterfaces;

namespace ShopApplication.Logic;

public class OrderItemLogic : IOrderItemLogic
{
    private readonly IOrderItemDao orderItemDao;

    public OrderItemLogic(IOrderItemDao orderItemDao)
    {
        this.orderItemDao = orderItemDao;
    }

    public Task<List<OrderItem>> GetAllOrderItemsAsync()
    {
        return orderItemDao.GetAllOrderItemsAsync();
    }
}