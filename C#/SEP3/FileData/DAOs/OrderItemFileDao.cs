using Shared;
using ShopApplication.DaoInterfaces;

namespace FileData.DAOs;

public class OrderItemFileDao : IOrderItemDao
{
    private readonly FileContext context;

    public OrderItemFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<List<OrderItem>> GetAllOrderItemsAsync()
    {
        IEnumerable<OrderItem> orderItems = context.OrderItems.AsEnumerable();

        List<OrderItem> orderItemsList = new List<OrderItem>();

        foreach (OrderItem orderItem in orderItems)
        {
            orderItemsList.Add(orderItem);
        }

        return Task.FromResult(orderItemsList);
    }

    public Task<OrderItem> OrderProduct(long id, int quantity)
    {
        Product product = context.getProductById(id);
        double price = product.price * quantity;
        OrderItem orderItem = new OrderItem(product, quantity, price);

        context.OrderItems.Add(orderItem);
        context.SaveChanges();

        return Task.FromResult(orderItem);
    }
}