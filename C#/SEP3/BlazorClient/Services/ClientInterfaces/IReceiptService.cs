using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.ClientInterfaces;

public interface IReceiptService
{
    Task<Receipt> CreateAsync(ReceiptCreationDto purchaseToCreate);
    
    Task<ReceiptGetDto> GetByIdAsync(long id);
    Task<IEnumerable<Receipt>> GetAsync(long? idContains=null);
}