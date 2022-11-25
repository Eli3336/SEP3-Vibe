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
    public Task<OrderItem> OrderProduct(OrderItem orderItem)
    {
        long id = 1;
        if (context.OrderItems.Any())
        {
            id = context.OrderItems.Max(t => t.id);
            id++;
        }

        orderItem.id = id;
        
        context.OrderItems.Add(orderItem);
        context.SaveChanges();

        return Task.FromResult(orderItem);
    }

    public Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemsParametersDto parametersDto)
    {
        IEnumerable<OrderItem> orderItems = context.OrderItems.AsEnumerable();
        if (parametersDto.id != null)
        {
            orderItems = context.OrderItems.Where(o => o.product.id == parametersDto.id);
        }

        return Task.FromResult(orderItems);
    }

    public Task UpdateAsync(OrderItem orderItem)
    {
        OrderItem? existing = context.OrderItems.FirstOrDefault(todo => todo.id == orderItem.id);
        if (existing == null)
        {
            throw new Exception($"Order with id {orderItem.id} does not exist!");
        }

        context.OrderItems.Remove(existing);
        context.OrderItems.Add(orderItem);
        
        context.SaveChanges();
        
        return Task.CompletedTask;
    }

    public Task<OrderItem> GetByIdAsync(long id)
    {
        OrderItem? existing = context.OrderItems.FirstOrDefault(t => t.id == id);
        return Task.FromResult(existing);
    }

    public Task DeleteAsync(long id)
    {
        OrderItem? existing = context.OrderItems.FirstOrDefault(orderItem => orderItem.id == id);
        if (existing == null)
        {
            throw new Exception($"OrderItem with id {id} does not exist!");
        }

        context.OrderItems.Remove(existing); 
        context.SaveChanges();
    
        return Task.CompletedTask;
    }
}