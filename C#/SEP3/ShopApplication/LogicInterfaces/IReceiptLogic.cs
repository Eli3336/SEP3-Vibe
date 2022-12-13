using Shared;
using Shared.DTOs;

namespace ShopApplication.LogicInterfaces;

public interface IReceiptLogic
{
    Task<Receipt> CreateAsync(ReceiptCreationDto receiptToCreate);
    
    Task<ReceiptGetDto> GetByIdAsync(long id);
    Task<IEnumerable<Receipt>> GetAsync(SearchReceiptParametersDto parametersDto);
    Task<IEnumerable<Receipt>> GetByUserIdAsync(long id);
}