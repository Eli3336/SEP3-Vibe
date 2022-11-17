using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace FileData.DAOs;

public class CustomerFileDao : ICustomerDao
{
    private readonly FileContext context;

    public CustomerFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Customer> CreateAsync(Customer customer)
    {
        int customerId = 1;
        if (context.Customers.Any())
        {
            customerId = context.Customers.Max(c => c.Id);
            customerId++;
        }

        customer.Id = customerId;

        context.Customers.Add(customer);
        context.SaveChanges();

        return Task.FromResult(customer);
    }

    public Task<Customer?> GetByUsernameAsync(string userName)
    {
        Customer? existing = context.Customers.FirstOrDefault(c =>
            c.username.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Customer>> GetAsync(SearchCustomerParametersDto? searchParameters)
    {
        IEnumerable<Customer> customers = context.Customers.AsEnumerable();
        if (searchParameters.UsernameContains != null)
        {
            customers = context.Customers.Where(c =>
                c.username.Contains(searchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(customers);
    }
}