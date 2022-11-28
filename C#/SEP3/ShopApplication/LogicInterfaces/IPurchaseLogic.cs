using Shared;

namespace ShopApplication.LogicInterfaces;

public interface IPurchaseLogic
{
    Task<Purchase> CreateAsync(PurchaseCreationDto purchaseToCreate);
    
    Task<PurchaseCreationDto> GetByIdAsync(long id);

}