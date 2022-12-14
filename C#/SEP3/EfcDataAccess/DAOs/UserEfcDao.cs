using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly ShopContext context;

    public UserEfcDao(ShopContext context)
    {
        this.context = context;
    }

    public async Task<string> Seed()
    {
        List<User> users = context.Users.ToList();
        for (int i = 0; i < users.Count; i++)
        {
            User? existing = users[i];
            if (existing == null)
            {
                throw new Exception($"User with id {users[i].Id} not found");
            }
            context.Users.Remove(existing);
            await context.SaveChangesAsync();    
        }
        await context.SaveChangesAsync();
        User toCreate = new User
        {
            Id = 1,
            name = "Ana Aninsen",
            phoneNumber = "5012345678",
            username = "Ana",
            password = "Banana1234",
            SecurityLevel = 1
        };
        await context.Users.AddAsync(toCreate);
        await context.SaveChangesAsync();
        User toCreate1 = new User
        {
            Id = 2,
            name = "Admin Adminsen",
            phoneNumber = "5087654321",
            username = "admin",
            password = "Admin1234",
            SecurityLevel = 2
        };
       await context.Users.AddAsync(toCreate1);
       await context.SaveChangesAsync();

       return "Ok";
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.username.ToLower().Equals(userName.ToLower())
        );
        return existing;
    }

    public async Task<IEnumerable<User>> GetAsync(SearchUserParametersDto? searchParameters)
    {
        IQueryable<User> usersQuery = context.Users.AsQueryable();
        if (searchParameters?.UsernameContains != null)
        {
            usersQuery = context.Users.Where(u =>
                u.username.Contains(searchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }
        IEnumerable<User> result = await usersQuery.ToListAsync();
        return await Task.FromResult(result);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.Id==id);
        return existing;    }
}