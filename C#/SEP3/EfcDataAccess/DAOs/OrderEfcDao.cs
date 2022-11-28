using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class OrderEfcDao : IOrderDao
{
    private readonly TodoContext context;

    public OrderEfcDao(TodoContext context)
    {
        this.context = context;
    }
    public async Task<Order> CreateAsync(Order order)
    {
        EntityEntry<Order> newOrder = await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return newOrder.Entity;
    }

    public async Task<Order?> GetByIdAsync(long id)
    {
        Order? existing = await context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        return existing;
    }

    public async Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto? searchParameters)
    {

        IQueryable<Order> ordersQuery = context.Orders.AsQueryable();
        if (searchParameters.Id != null)
        {
            ordersQuery = ordersQuery.Where(o => o.Id == searchParameters.Id);
        }

        IEnumerable<Order> result = await ordersQuery.ToListAsync();
        return result;
        
    }
}