namespace Shared.DTOs;

public class OrderItemCreationDto
{
    public long ProductId { get;}
    public int Quantity{ get;}
    

    public OrderItemCreationDto(long productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
}