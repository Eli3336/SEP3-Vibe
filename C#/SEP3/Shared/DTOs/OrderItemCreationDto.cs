namespace Shared.DTOs;

public class OrderItemCreationDto
{
    public long productId { get; set; }
    public int quantity{ get; set; }
    

    public OrderItemCreationDto(long productId, int quantity)
    {
        this.productId = productId;
        this.quantity = quantity;
    }
}