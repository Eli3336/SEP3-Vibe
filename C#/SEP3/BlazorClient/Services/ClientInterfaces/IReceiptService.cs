using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.ClientInterfaces;

public interface IReceiptService
{
    Task<Receipt> CreateAsync(ReceiptCreationDto purchaseToCreate);
    
    Task<ReceiptCreationDto> GetByIdAsync(long id);
    Task<ICollection<Receipt>> GetAsync(long? idContains=null);
}