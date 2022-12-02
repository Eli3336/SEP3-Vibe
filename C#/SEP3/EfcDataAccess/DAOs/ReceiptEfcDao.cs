using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class PurchaseEfcDao : IReceiptDao
{
    
    private readonly ShopContext context;

    public PurchaseEfcDao(ShopContext context)
    {
        this.context = context;
    }
    
    public async Task<Receipt> CreateAsync(Receipt receipt)
    {
        EntityEntry<Receipt> newOrder = await context.Receipts.AddAsync(receipt);
        await context.SaveChangesAsync();
        return newOrder.Entity;    }

    public async Task<Receipt?> GetByIdAsync(long id)
    {
        Receipt? existing = await context.Receipts.FirstOrDefaultAsync(t => t.id == id);
        return await Task.FromResult(existing);    }
}