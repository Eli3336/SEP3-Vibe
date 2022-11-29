using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class PurchaseEfcDao : IPurchaseDao
{
    
    private readonly ShopContext context;

    public PurchaseEfcDao(ShopContext context)
    {
        this.context = context;
    }
    
    public async Task<Purchase> CreateAsync(Purchase purchase)
    {
        EntityEntry<Purchase> newOrder = await context.Purchases.AddAsync(purchase);
        await context.SaveChangesAsync();
        return newOrder.Entity;    }

    public async Task<Purchase?> GetByIdAsync(long id)
    {
        Purchase? existing = await context.Purchases.FirstOrDefaultAsync(t => t.userId == id);
        return await Task.FromResult(existing);    }
}