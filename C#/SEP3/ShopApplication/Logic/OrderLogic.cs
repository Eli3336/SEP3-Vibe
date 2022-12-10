using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using ShopApplication.LogicInterfaces;

namespace ShopApplication.Logic;

public class OrderLogic : IOrderLogic
{

    private readonly IOrderDao orderDao;
    private readonly IOrderItemDao orderItemDao;

    public OrderLogic(IOrderDao orderDao, IOrderItemDao orderItemDao)
    {
        this.orderDao = orderDao;
        this.orderItemDao = orderItemDao;
    }

    public async Task<Order> CreateAsync(OrderCreationDto dto)
    {
        List<OrderItem> orderItems = new List<OrderItem>();
        foreach (var itemId in dto.itemsId)
        {
            OrderItem? item = await orderItemDao.GetByIdAsync(itemId);
            if (item==null)
            {
                throw new Exception($"OrderItem with id: {itemId} was not found");
            }
            if(item.hasBeenBought == false)
                orderItems.Add(item);
        }
        double price = 0;
        foreach (var order in orderItems)
        {
            price += order.price;
        }
        ValidateData(dto);
        Order toCreate = new Order(DateTime.Today, price, dto.address, orderItems);
        Order created = await orderDao.CreateAsync(toCreate);
        return created;
    }

    public async Task<Order> CreateAdminOrderAsync(OrderCreationDto orderToCreate)
    {
        throw new NotImplementedException();

    }

    public Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto? searchParameters)
    {
        return orderDao.GetAsync(searchParameters);
    }

    public async Task<OrderGetDto> GetByIdAsync(long id)
    {
        Order? order = await orderDao.GetByIdAsync(id);
        if (order == null)
        {
            throw new Exception($"Order with id {id} not found");
        }

        return new OrderGetDto(order.orderDate, order.orderPrice,order.address,order.items);
    }

    private static void ValidateData(OrderCreationDto orderToCreate)
    {
        string address = orderToCreate.address;

        if (address.Length < 3)
            throw new Exception("Address must be at least 3 characters!");

        if (address.Length > 150)
            throw new Exception("Address must be less than 150 characters!");
    }
    
}