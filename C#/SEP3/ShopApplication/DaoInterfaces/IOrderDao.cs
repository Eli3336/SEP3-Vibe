using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface IOrderDao
{
    Task<Order> CreateAsync(Order order);
    Task<Order?> GetByIdAsync(long id);
    Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto? searchParameters);
    
   

}