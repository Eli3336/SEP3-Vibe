using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace FileData.DAOs;

public class OrderItemFileDao : IOrderItemDao
{
    private readonly FileContext context;

    public OrderItemFileDao(FileContext context)
    {
        this.context = context;
    }

   /* public Task<List<OrderItem>> GetAllOrderItemsAsync()
    {
        IEnumerable<OrderItem> orderItems = context.OrderItems.AsEnumerable();

        List<OrderItem> orderItemsList = new List<OrderItem>();

        foreach (OrderItem orderItem in orderItems)
        {
            orderItemsList.Add(orderItem);
        }

        return Task.FromResult(orderItemsList);
    }*/

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

    public Task<OrderItem?> GetByIdAsync(long id)
    {
        OrderItem? existing = context.OrderItems.FirstOrDefault(t => t.id == id);
        return Task.FromResult(existing);
    }
    
    public Task UpdateAsync(OrderItem toUpdate)
    {
        OrderItem? existing = context.OrderItems.FirstOrDefault(todo => todo.id == toUpdate.id);
        if (existing == null)
        {
            throw new Exception($"Order with id {toUpdate.id} does not exist!");
        }

        context.OrderItems.Remove(existing);
        context.OrderItems.Add(toUpdate);
        
        context.SaveChanges();
        
        return Task.CompletedTask;
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