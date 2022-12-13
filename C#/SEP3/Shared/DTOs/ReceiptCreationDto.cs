namespace Shared.DTOs;

public class ReceiptCreationDto
{
    public string userName { get; set; }

    public long orderId { get; set; }
    

    public ReceiptCreationDto(string userName, long orderId)
    {

        this.userName = userName;
        this.orderId = orderId;
    }
}