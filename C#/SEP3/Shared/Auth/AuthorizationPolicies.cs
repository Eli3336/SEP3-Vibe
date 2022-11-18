using Microsoft.Extensions.DependencyInjection;
namespace Shared.Auth;

public static class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("MustBeLoggedIn", a =>
                a.RequireAuthenticatedUser());
    // Authenticated User is a built in function, no need for customer definition
            
                
        });
    }   
}