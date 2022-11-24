using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class OrderEfcDao : IOrderDao
{
    public Task<Order> CreateAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task<Order?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto? searchParameters)
    {
        throw new NotImplementedException();
    }
}