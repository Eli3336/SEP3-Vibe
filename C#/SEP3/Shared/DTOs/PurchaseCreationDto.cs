namespace Shared.DTOs;

public class PurchaseCreationDto
{
    public string userName { get; set; }

    public Order order { get; set; }

    public PurchaseCreationDto(string userName, Order order)
    {

        this.userName = userName;
        this.order = order;
    }
}