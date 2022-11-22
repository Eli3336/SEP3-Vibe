namespace Shared.DTOs;

public class OrderItemCreationDto
{
    public long productId { get; set; }
    public int quantity{ get;}
    

    public OrderItemCreationDto(long productId, int quantity)
    {
        this.productId = productId;
        this.quantity = quantity;
    }
}