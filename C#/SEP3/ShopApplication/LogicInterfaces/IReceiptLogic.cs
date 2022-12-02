using Shared;
using Shared.DTOs;

namespace ShopApplication.LogicInterfaces;

public interface IReceiptLogic
{
    Task<Receipt> CreateAsync(ReceiptCreationDto receiptToCreate);
    
    Task<ReceiptCreationDto> GetByIdAsync(long id);
    Task<ICollection<Receipt>> GetAsync(string? nameContains=null);

}