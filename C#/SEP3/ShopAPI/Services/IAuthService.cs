using Shared;

namespace Shop.Services;
public interface IAuthService
{
    Task<Customer> ValidateCustomer(string username, string password);
    Task RegisterCustomer(Customer customer);
}