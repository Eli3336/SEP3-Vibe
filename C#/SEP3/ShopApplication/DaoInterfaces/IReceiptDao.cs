using Shared;
using Shared.DTOs;

namespace ShopApplication.DaoInterfaces;

public interface IReceiptDao
{
    Task<Receipt> CreateAsync(Receipt purchase);
    
    Task<Receipt?> GetByIdAsync(long id);
    Task<IEnumerable<Receipt>> GetAsync(SearchReceiptParametersDto parametersDto);

}