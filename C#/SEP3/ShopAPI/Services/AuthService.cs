using System.ComponentModel.DataAnnotations;
using FileData;
using Shared;

namespace Shop.Services;


public class AuthService:IAuthService
{

    public FileContext context = new FileContext();

    private readonly IList<Customer> customers = new List<Customer>
    {
        
    };
    public Task<Customer> ValidateCustomer(string username, string password)
    {

        Customer? existingCustomer = context.Customers.FirstOrDefault(c => 
            c.username.Equals(username, StringComparison.OrdinalIgnoreCase));
        
        if (existingCustomer == null)
        {
            throw new Exception("Customer not found");
        }

        if (!existingCustomer.password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingCustomer);
    }

    public Task RegisterCustomer(Customer customer)
    {

        if (string.IsNullOrEmpty(customer.username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(customer.password))
        {
            throw new ValidationException("Password cannot be null");
        }
        
        
        customers.Add(customer);
        context.Customers.Add(customer);
        return Task.CompletedTask;
    }
}