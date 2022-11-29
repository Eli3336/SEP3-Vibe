namespace Shared.DTOs;

public class PurchaseCreationDto
{
    public long id { get; set; }

    public List<OrderItem> orderItem { get; set; }

    public PurchaseCreationDto(long id, List<OrderItem> orderItem)
    {

        this.id = id;
        this.orderItem = orderItem;
    }
}