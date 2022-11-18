using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using ShopApplication.LogicInterfaces;

namespace ShopApplication.Logic;

public class OrderItemLogic : IOrderItemLogic
{
    private readonly IOrderItemDao orderItemDao;
    private readonly IProductDao productDao;


    public OrderItemLogic(IOrderItemDao orderItemDao, IProductDao productDao)
    {
        this.orderItemDao = orderItemDao;
        this.productDao = productDao;
    }

    // public Task<List<OrderItem>> GetAllOrderItemsAsync()
    // {
        // return orderItemDao.GetAllOrderItemsAsync();
    // }

    public Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemsParametersDto parametersDto)
    {
        return orderItemDao.GetAsync(parametersDto);
    }

    public async Task<OrderItem> OrderProduct(OrderItemCreationDto dto)
    {
        Product? product = await productDao.GetByIdAsync(dto.ProductId);
        if (product==null)
        {
            throw new Exception($"Product with id: {dto.ProductId} was not found");
        }

        double price = product.price;
        
        ValidateData(dto);
        OrderItem orderItem = new OrderItem(product, dto.Quantity, price*dto.Quantity);
        OrderItem created = await orderItemDao.OrderProduct(orderItem);
        return created;
    }

    private static void ValidateData(OrderItemCreationDto orderToCreate)
    {
        
        int quantity = orderToCreate.Quantity;

        if (quantity<1)
        {
            throw new Exception("The quantity is incorrect");
        }
    }
}