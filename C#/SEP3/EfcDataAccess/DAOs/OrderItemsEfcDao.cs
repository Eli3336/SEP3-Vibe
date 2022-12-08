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
        IQueryable<OrderItem> orderItems = context.OrderItems
            .Include(orderItem => orderItem.product)
            .Include(o=>o.product.category)
            .AsQueryable();
        if (searchParameters.id != null)
        {
            orderItems = orderItems.Where(o => o.id == searchParameters.id);
        }

        IEnumerable<OrderItem> result = await orderItems.ToListAsync();
        return result;
    }

    public async Task UpdateAsync(OrderItem orderItem)
    {
        context.OrderItems.Update(orderItem);
        await context.SaveChangesAsync();
    }

    public async  Task<OrderItem?> GetByIdAsync(long id)
    {
        OrderItem? existing = await context.OrderItems
            //.AsNoTracking()
            //.FindAsync(id)
            .Include(orderItem => orderItem.product)
            .SingleOrDefaultAsync(t => t.id == id);
        return existing;
    }
    
    public async  Task<OrderItem?> GetByIdToUpdateAsync(long id)
    {
        OrderItem? existing = await context.OrderItems
            .AsNoTracking().Include(orderItem => orderItem.product)
            .SingleOrDefaultAsync(t => t.id == id);
        return existing;
    }

    public async Task DeleteAsync(long id)
    {
        OrderItem? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"OrderItem with id {id} not found");
        }

        context.OrderItems.Remove(existing);
        await context.SaveChangesAsync();
    }
}