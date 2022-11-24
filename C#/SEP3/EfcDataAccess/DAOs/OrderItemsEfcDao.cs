using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class OrderItemsEfcDao : IOrderItemDao
{
    public Task<OrderItem> OrderProduct(OrderItem orderItem)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemsParametersDto parametersDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(OrderItem orderItem)
    {
        throw new NotImplementedException();
    }

    public Task<OrderItem> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }
}