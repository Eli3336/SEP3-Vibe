using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.ClientInterfaces;

public interface IPurchaseService
{
    Task<Purchase> CreateAsync(PurchaseCreationDto purchaseToCreate);
    
    Task<PurchaseCreationDto> GetByIdAsync(long id);
    Task<ICollection<Purchase>> GetAsync(long? idContains=null);
}