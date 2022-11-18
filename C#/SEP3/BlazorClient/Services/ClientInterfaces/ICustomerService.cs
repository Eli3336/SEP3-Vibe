using Shared.DTOs;
using Shared.domain;
using Shared;

namespace BlazorApp.Services.ClientInterfaces;

public interface ICustomerService
{
    Task<Customer> Create(CustomerCreationDto dto);
}