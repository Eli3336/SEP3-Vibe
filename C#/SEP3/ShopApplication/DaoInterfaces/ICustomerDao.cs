using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface ICustomerDao
{
    Task<Customer> CreateAsync(Customer user);
    Task<Customer?> GetByUsernameAsync(string userName);
    Task<IEnumerable<Customer>> GetAsync(SearchCustomerParametersDto? searchParameters);
}