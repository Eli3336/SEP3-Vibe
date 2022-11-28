using Shared;

namespace ShopApplication.DaoInterfaces;

public interface IPurchaseDao
{
    Task<Purchase> CreateAsync(Purchase purchase);
    
    Task<Purchase?> GetByIdAsync(long id);

}