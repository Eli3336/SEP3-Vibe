using Shared;

namespace ShopApplication.DaoInterfaces;

public interface IReceiptDao
{
    Task<Receipt> CreateAsync(Receipt purchase);
    
    Task<Receipt?> GetByIdAsync(long id);

}