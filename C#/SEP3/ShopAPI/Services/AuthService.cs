using System.ComponentModel.DataAnnotations;
using EfcDataAccess;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace Shop.Services;


public class AuthService:IAuthService
{

    private readonly IUserDao userDao;

    public AuthService(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    private readonly IList<User> users = new List<User>
    {
        
    };
    public async Task<User> ValidateUser(string username, string password)
    {

        User? existingUser = await userDao.GetByUsernameAsync(username);
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }

    public async Task<User> RegisterUser(UserCreationDto dto)
    {
        
        if (string.IsNullOrEmpty(dto.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(dto.Password))
        {
            throw new ValidationException("Password cannot be null");
        }

        User user = new User(dto.Name, dto.PhoneNumber, dto.UserName, dto.Password, new ShoppingCart());
        users.Add(user);
        User userToCreate = await userDao.CreateAsync(user);
        return userToCreate;
    }
}