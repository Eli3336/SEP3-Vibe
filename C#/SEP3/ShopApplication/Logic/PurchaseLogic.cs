using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using ShopApplication.LogicInterfaces;

namespace ShopApplication.Logic;

public class PurchaseLogic : IPurchaseLogic
{
    private readonly IPurchaseDao purchaseDao;

    public PurchaseLogic(IPurchaseDao purchaseDao)
    {
        this.purchaseDao = purchaseDao;
    }

    public async Task<Purchase> CreateAsync(PurchaseCreationDto purchaseToCreate)
    {
        Purchase toCreate = new Purchase
        {
            userId = purchaseToCreate.id,
            orderItems = purchaseToCreate.orderItem,
        };
    
        Purchase created = await purchaseDao.CreateAsync(toCreate);
    
        return created;    }

    public async Task<PurchaseCreationDto> GetByIdAsync(long id)
    {
        Purchase? purchase = await purchaseDao.GetByIdAsync(id);
        if (purchase == null)
        {
            throw new Exception(
                $"Purchase with id {id} not found!");
        }

        return new PurchaseCreationDto(purchase.userId, purchase.orderItems);
    }
}