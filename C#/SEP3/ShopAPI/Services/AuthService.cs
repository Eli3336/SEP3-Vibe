using System.ComponentModel.DataAnnotations;
using EfcDataAccess;
using Shared;

namespace Shop.Services;


public class AuthService:IAuthService
{

    public ShopContext context = new ShopContext();

    private readonly IList<User> users = new List<User>
    {
        
    };
    public Task<User> ValidateUser(string username, string password)
    {

        User? existingUser = context.Users.FirstOrDefault(u => 
            u.username.Equals(username));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.password))
        {
            throw new ValidationException("Password cannot be null");
        }
        
        
        users.Add(user);
        context.Users.Add(user);
        return Task.CompletedTask;
    }
}