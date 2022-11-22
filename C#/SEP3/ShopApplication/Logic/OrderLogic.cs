using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using ShopApplication.LogicInterfaces;

namespace ShopApplication.Logic;

public class OrderLogic : IOrderLogic
{

    private readonly IOrderDao orderDao;

    public OrderLogic(IOrderDao orderDao)
    {
        this.orderDao = orderDao;
    }

    public async Task<Order> CreateAsync(OrderCreationDto dto)
    {
        Order? existing = await orderDao.GetByIdAsync(dto.Id);
        if (existing != null)
            throw new Exception("Id already taken!");

        try
        {
            ValidateData(dto);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        Order toCreate = new Order
        {
            address = dto.Address
        };

        Order created = await orderDao.CreateAsync(toCreate);

        return created;
    }

    public Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto? searchParameters)
    {
        return orderDao.GetAsync(searchParameters);
    }

    private static void ValidateData(OrderCreationDto orderToCreate)
    {
        string address = orderToCreate.Address;

        if (address.Length < 3)
            throw new Exception("Address must be at least 3 characters!");

        if (address.Length > 150)
            throw new Exception("Address must be less than 150 characters!");
    }
}