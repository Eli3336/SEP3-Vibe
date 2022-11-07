using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using ShopApplication.LogicInterfaces;

namespace ShopApplication.Logic;

public class OrderItemLogic : IOrderItemLogic
{
    private readonly IOrderItemDao orderItemDao;

    public OrderItemLogic(IOrderItemDao orderItemDao)
    {
        this.orderItemDao = orderItemDao;
    }

    // public Task<List<OrderItem>> GetAllOrderItemsAsync()
    // {
        // return orderItemDao.GetAllOrderItemsAsync();
    // }

    public Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemsParametersDto parametersDto)
    {
        return orderItemDao.GetAsync(parametersDto);
    }

    public Task<OrderItem> OrderProduct(long id, int quantity)
    {
        return orderItemDao.OrderProduct(id, quantity);
    }
}