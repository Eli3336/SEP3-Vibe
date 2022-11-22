using Shared;
using Shared.DTOs;

namespace ShopApplication.LogicInterfaces;

public interface ICustomerLogic
{
    Task<Customer> CreateAsync(CustomerCreationDto customerToCreate);
    Task<IEnumerable<Customer>> GetAsync(SearchCustomerParametersDto? searchParameters);
}