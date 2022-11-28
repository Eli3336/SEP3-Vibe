using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            usersQuery = usersQuery.Where(u => u.username.ToLower().Contains(searchParameters.UsernameContains.ToLower()));
        }

        IEnumerable<User> result = await usersQuery.ToListAsync();
        return result;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.Id==id);
        return existing;    }
}