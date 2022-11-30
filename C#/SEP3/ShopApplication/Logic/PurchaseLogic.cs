using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using ShopApplication.LogicInterfaces;

namespace ShopApplication.Logic;

public class PurchaseLogic : IPurchaseLogic
{
    private readonly IPurchaseDao purchaseDao;
    private readonly IUserDao userDao;

    public PurchaseLogic(IPurchaseDao purchaseDao, IUserDao userDao)
    {
        this.purchaseDao = purchaseDao;
        this.userDao = userDao;
    }

    public async Task<Purchase> CreateAsync(PurchaseCreationDto purchaseToCreate)
    {
        User? user = await userDao.GetByUsernameAsync(purchaseToCreate.userName);
        if (user==null)
        {
            throw new Exception($"User with username: {purchaseToCreate.userName} was not found");
        }
        
        Purchase toCreate = new Purchase(user,purchaseToCreate.order,purchaseToCreate.order.orderPrice);
        Purchase created = await purchaseDao.CreateAsync(toCreate);
    
        return created;
    }

    public async Task<PurchaseCreationDto> GetByIdAsync(long id)
    {
        Purchase? purchase = await purchaseDao.GetByIdAsync(id);
        if (purchase == null)
        {
            throw new Exception(
                $"Purchase with id {id} not found!");
        }

        return new PurchaseCreationDto(purchase.user.name, purchase.order);
    }
}