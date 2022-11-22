using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace FileData.DAOs;

public class OrderFileDao : IOrderDao
{
    private readonly FileContext context;

    public OrderFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Order> CreateAsync(Order order)
    {
        long orderId = 1;
        if (context.Orders.Any())
        {
            orderId = context.Orders.Max(c => c.Id);
            orderId++;
        }

        order.Id = orderId;

        context.Orders.Add(order);
        context.SaveChanges();

        return Task.FromResult(order);
    }

    public Task<Order?> GetByIdAsync(long id)
    {
        Order? existing = context.Orders.FirstOrDefault(o => o.Id == id);
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto? searchParameters)
    {
        IEnumerable<Order> orders = context.Orders.AsEnumerable();
        if (searchParameters?.Id != null)
        {
            orders = context.Orders.Where(o => o.Id == searchParameters.Id);
        }

        return Task.FromResult(orders);
    }
}