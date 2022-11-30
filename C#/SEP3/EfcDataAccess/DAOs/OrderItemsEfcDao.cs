using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class OrderItemsEfcDao : IOrderItemDao
{
    private readonly TodoContext context;

    public OrderItemsEfcDao(TodoContext context)
    {
        this.context = context;
    }
    public async Task<OrderItem> OrderProduct(OrderItem orderItem)
    {
        EntityEntry<OrderItem> newOrder = await context.OrderItems.AddAsync(orderItem);
        await context.SaveChangesAsync();
        return newOrder.Entity;
    }

    public async Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemsParametersDto parametersDto)
    {
        IQueryable<OrderItem> orderItems = context.OrderItems.Include(orderItem => orderItem.product).AsQueryable();
        if (parametersDto.id !=null)
        {
            orderItems = orderItems.Where(o => o.product.id == parametersDto.id);
        }
        
        
        List<OrderItem> result = await orderItems.ToListAsync();
        return result;
    }

    public async Task UpdateAsync(OrderItem orderItem)
    {
        
        context.OrderItems.Update(orderItem);
        await context.SaveChangesAsync();
    }

    public async Task<OrderItem> GetByIdAsync(long id)
    {
        OrderItem? existing = await context.OrderItems
            .AsNoTracking()
            .Include(orderItem => orderItem.product)
            .SingleOrDefaultAsync(t => t.id == id);
        return existing;
    }

    public async Task DeleteAsync(long id)
    {
        OrderItem? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"OrderItem with id {id} does not exist!");
        }
        
        context.OrderItems.Remove(existing); 
        await context.SaveChangesAsync();
    }
}