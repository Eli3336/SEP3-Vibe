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
        IQueryable<OrderItem> orderItems = context.OrderItems.AsQueryable();
        if (parametersDto.id != null)
        {
            orderItems = context.OrderItems.Where(o => o.product.id == parametersDto.id);
        }
        
        IEnumerable<OrderItem> result = await orderItems.ToListAsync();
        return result;
    }

    public async Task UpdateAsync(OrderItem orderItem)
    {
        OrderItem? existing = await context.OrderItems.FirstOrDefaultAsync(todo => todo.id == orderItem.id);
        if (existing == null)
        {
            throw new Exception($"Order with id {orderItem.id} does not exist!");
        }

        context.OrderItems.Remove(existing);
        context.OrderItems.Add(orderItem);
        
        context.SaveChanges();
    }

    public async Task<OrderItem> GetByIdAsync(long id)
    {
        OrderItem? existing = await context.OrderItems.FirstOrDefaultAsync(t => t.id == id);
        return await Task.FromResult(existing);
        
    }

    public async Task DeleteAsync(long id)
    {
        OrderItem? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"OrderItem with id {id} does not exist!");
        }
        
        context.OrderItems.Remove(existing); 
        context.SaveChanges();
    }
}