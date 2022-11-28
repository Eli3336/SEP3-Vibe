using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);
}