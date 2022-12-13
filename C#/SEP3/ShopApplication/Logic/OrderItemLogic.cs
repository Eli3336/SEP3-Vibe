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

        Product? product = await productDao.GetByIdAsync(dto.productId);
        if (product==null)
        {
            throw new Exception($"Product with id: {dto.productId} was not found");
        }

        double price = product.price;
        
        ValidateData(dto);
        OrderItem orderItem = new OrderItem(product, dto.quantity, price*dto.quantity, false);
        OrderItem created = await orderItemDao.OrderProduct(orderItem);
        return created;
    }
 
    public async Task UpdateAsync(OrderItemUpdateDto dto)
    {   
        OrderItem? existing = await orderItemDao.GetByIdToUpdateAsync(dto.id);

        if (existing == null)
        {
            throw new Exception($"Order with ID {dto.id} not found!");
        }
        
        Product? product = null;

        Product productToUse = product ?? existing.product;
        int quantity = dto.quantity ?? existing.quantity;


        OrderItem updated = new ( productToUse, quantity, quantity*productToUse.price, existing.hasBeenBought)
        {
            id=existing.id
        };
        
        await orderItemDao.UpdateAsync(updated);
    }

    public async Task BuyAsync(OrderItemUpdateDto dto)
    {
        OrderItem? existing = await orderItemDao.GetByIdToUpdateAsync(dto.id);

        if (existing == null)
        {
            throw new Exception($"Order with ID {dto.id} not found!");
        }

        OrderItem updated = new (dto.hasBeenBought)
        {
            id=existing.id,
            quantity = existing.quantity
        };
        
        await orderItemDao.BuyAsync(updated);
    }


    private static void ValidateData(OrderItemCreationDto orderToCreate)
    {
        
        int quantity = orderToCreate.quantity;
        if (quantity<1)
        {
            throw new Exception("The quantity is incorrect");
        }
    }
    
    public async Task DeleteAsync(long id)
    {
        OrderItem? orderItem = await orderItemDao.GetByIdAsync(id);
        if (orderItem == null)
        {
            throw new Exception($"OrderItem with ID {id} was not found!");
        }

        await orderItemDao.DeleteAsync(id);
    }
    
    public async Task<OrderItemGetDto> GetByIdAsync(long id)
    {
        OrderItem? orderItem = await orderItemDao.GetByIdAsync(id);
        if (orderItem == null)
        {
            throw new Exception($"OrderItem with id {id} not found");
        }

        return new OrderItemGetDto(orderItem.product, orderItem.quantity, orderItem.price, orderItem.hasBeenBought);
    }

    public async Task<IEnumerable<OrderItem>> GetNotBoughtOrderItems()
    {
        return await orderItemDao.GetNotBoughtOrderItemsAsync();
    }
}