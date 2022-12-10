using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using ShopApplication.LogicInterfaces;

namespace ShopApplication.Logic;

public class ReceiptLogic : IReceiptLogic
{
    private readonly IReceiptDao receiptDao;
    private readonly IUserDao userDao;
    private readonly IOrderDao orderDao;

    public ReceiptLogic(IReceiptDao receiptDao, IUserDao userDao, IOrderDao orderDao)
    {
        this.receiptDao = receiptDao;
        this.userDao = userDao;
        this.orderDao = orderDao;
    }

    public async Task<Receipt> CreateAsync(ReceiptCreationDto receiptToCreate)
    {
        User? user = await userDao.GetByUsernameAsync(receiptToCreate.userName);
        if (user==null)
        {
            throw new Exception($"User with username: {receiptToCreate.userName} was not found");
        }

       Order order = await orderDao.GetByIdAsync(receiptToCreate.orderId);
        if (order==null)
        {
            throw new Exception($"No order with {receiptToCreate.orderId} was found");
        }
        
        Receipt toCreate = new Receipt(user, order, order.orderPrice);
        Receipt created = await receiptDao.CreateAsync(toCreate);
        return created;
    }

    public async Task<ReceiptGetDto> GetByIdAsync(long id)
    {
        Receipt? receipt = await receiptDao.GetByIdAsync(id);
        if (receipt == null)
        {
            throw new Exception(
                $"Receipt with id {id} not found!");
        }

        return new ReceiptGetDto(receipt.user, receipt.order);
    }

    public Task<IEnumerable<Receipt>> GetAsync(SearchReceiptParametersDto parametersDto)
    {
        return receiptDao.GetAsync(parametersDto);
    }
}