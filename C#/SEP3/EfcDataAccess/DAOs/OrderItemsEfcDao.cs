using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class OrderItemsEfcDao : IOrderItemDao
{

    private readonly ShopContext context;

    public OrderItemsEfcDao(ShopContext context)
    {
        this.context = context;
    }

    public async Task<OrderItem> OrderProduct(OrderItem orderItem)
    {
        EntityEntry<OrderItem> newOrderItem = await context.OrderItems.AddAsync(orderItem);
        await context.SaveChangesAsync();
        return newOrderItem.Entity;
    }

    public async Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemsParametersDto searchParameters)
    {
        IQueryable<OrderItem> orderItemsQuery = context.OrderItems.AsQueryable();
        if (searchParameters.id != null)
        {
            orderItemsQuery = orderItemsQuery.Where(o => o.id == searchParameters.id);
        }

        IEnumerable<OrderItem> result = await orderItemsQuery.ToListAsync();
        return result;
    }

    public async Task UpdateAsync(OrderItem orderItem)
    {
        context.ChangeTracker.Clear();
        context.OrderItems.Update(orderItem);
        await context.SaveChangesAsync();
    }

    public async  Task<OrderItem?> GetByIdAsync(long id)
    {
        
        OrderItem? found = await context.OrderItems
            .Include(orderItem => orderItem.id)
            .SingleOrDefaultAsync(orderItem => orderItem.id == id);
        return found;
        
    }

    public async Task DeleteAsync(long id)
    {
        OrderItem? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"OrderItem with id {id} not found");
        }

        context.OrderItems.Remove(existing);
        context.SaveChanges();    
    }
}