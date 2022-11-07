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

    public Task<OrderItem> OrderProduct(long id, int quantity)
    {
        List<Product> products = context.Products.ToList();
        Product product = new Product();
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].id == id)
            {
                product = products[i];
            }
        }
        double price = product.price * quantity;
        OrderItem orderItem = new OrderItem(product, quantity, price);

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
}