using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class ReceiptEfcDao : IReceiptDao
{
    
    private readonly ShopContext context;

    public ReceiptEfcDao(ShopContext context)
    {
        this.context = context;
    }
    
    public async Task<Receipt> CreateAsync(Receipt receipt)
    {
        EntityEntry<Receipt> newReceipt = await context.Receipts.AddAsync(receipt);
        await context.SaveChangesAsync();
        return newReceipt.Entity;    }

    public async Task<Receipt?> GetByIdAsync(long id)
    {
        Receipt? existing = await context.Receipts
            .Include(r=>r.order)
            .SingleOrDefaultAsync(t => t.id == id);
        return existing;
    }
    
    public async Task<IEnumerable<Receipt>> GetAsync(SearchReceiptParametersDto searchParameters)
    {
        IQueryable<Receipt> receipts= context.Receipts
            .Include(r => r.order)
            .ThenInclude(o=>o.items)
            .ThenInclude(i=>i.product)
            .ThenInclude(p=>p.category)
            .Include(r=>r.user)
            .AsQueryable();
        if (searchParameters.Id != null)
        {
            receipts = receipts.Where(r => r.id == searchParameters.Id);
        }

        IEnumerable<Receipt> result = await receipts.ToListAsync();
        return result;
    }
}