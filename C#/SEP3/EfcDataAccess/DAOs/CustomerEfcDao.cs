using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class CustomerEfcDao : ICustomerDao
{
    public Task<Customer> CreateAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetByUsernameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAsync(SearchCustomerParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}