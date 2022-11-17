

using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.ClientInterfaces;

public interface ICustomerService
{
    Task<Customer> Create(CustomerCreationDto dto);
}