using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using ShopApplication.LogicInterfaces;

namespace ShopApplication.Logic;

public class CustomerLogic : ICustomerLogic
{
    private readonly ICustomerDao customerDao;

    public CustomerLogic(ICustomerDao customerDao)
    {
        this.customerDao = customerDao;
    }

    public async Task<Customer> CreateAsync(CustomerCreationDto dto)
    {
        Customer? existing = await customerDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        try
        {
            ValidateData(dto);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        Customer toCreate = new Customer
        {
            name = dto.Name,
            phoneNumber = dto.PhoneNumber,
            username = dto.UserName,
            password = dto.Password
        };
    
        Customer created = await customerDao.CreateAsync(toCreate);
    
        return created;
    }

    public Task<IEnumerable<Customer>> GetAsync(SearchCustomerParametersDto? searchParameters)
    {
        return customerDao.GetAsync(searchParameters);
    }

    private static void ValidateData(CustomerCreationDto customerToCreate)
    {
        string name = customerToCreate.Name;
        string phoneNumber = customerToCreate.PhoneNumber;
        string userName = customerToCreate.UserName;
        string password = customerToCreate.Password;

        if (name.Length < 3)
            throw new Exception("Name must be at least 3 characters!");

        if (name.Length > 50)
            throw new Exception("Name must be less than 50 characters!");
        
        if (phoneNumber.Length < 3)
            throw new Exception("Phone number must be at least 3 characters!");

        if (phoneNumber.Length > 30)
            throw new Exception("Phone number must be less than 16 characters!");
        
        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
        
        if (password.Length < 3)
            throw new Exception("Password must be at least 3 characters!");

        if (password.Length > 20)
            throw new Exception("Password must be less than 20 characters!");
    }
}