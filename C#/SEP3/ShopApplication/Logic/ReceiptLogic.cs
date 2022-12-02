using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using ShopApplication.LogicInterfaces;

namespace ShopApplication.Logic;

public class ReceiptLogic : IReceiptLogic
{
    private readonly IReceiptDao receiptDao;
    private readonly IUserDao userDao;

    public ReceiptLogic(IReceiptDao receiptDao, IUserDao userDao)
    {
        this.receiptDao = receiptDao;
        this.userDao = userDao;
    }

    public async Task<Receipt> CreateAsync(ReceiptCreationDto receiptToCreate)
    {
        User? user = await userDao.GetByUsernameAsync(receiptToCreate.user.username);
        if (user==null)
        {
            throw new Exception($"User with username: {receiptToCreate.user} was not found");
        }
        
        Receipt toCreate = new Receipt(user,receiptToCreate.order,receiptToCreate.order.orderPrice);
        Receipt created = await receiptDao.CreateAsync(toCreate);
    
        return created;
    }

    public async Task<ReceiptCreationDto> GetByIdAsync(long id)
    {
        Receipt? receipt = await receiptDao.GetByIdAsync(id);
        if (receipt == null)
        {
            throw new Exception(
                $"Purchase with id {id} not found!");
        }

        return new ReceiptCreationDto(receipt.user, receipt.order);
    }

    public Task<ICollection<Receipt>> GetAsync(string? nameContains = null)
    {
        throw new NotImplementedException();
    }
}