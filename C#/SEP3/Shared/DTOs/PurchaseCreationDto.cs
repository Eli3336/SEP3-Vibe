namespace Shared.DTOs;

public class PurchaseCreationDto
{
    public long id { get; set; }

    public Order order { get; set; }

    public PurchaseCreationDto(long id, Order order)
    {

        this.id = id;
        this.order = order;
    }
}