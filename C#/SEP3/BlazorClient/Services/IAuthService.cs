using System.Security.Claims;
using Shared;
using Shared.DTOs;

namespace BlazorClient.Services;

public interface IAuthService
{
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
    public Task<ClaimsPrincipal> GetAuthAsync();
    public Task RegisterAsync(UserCreationDto dto);

}