namespace Shared.DTOs;

public class OrderItemCreationDto
{
    public long productId { get; set; }
    public int quantity{ get; set; }
    public string username { get; set; }
    public OrderItemCreationDto(long productId, int quantity, string username)
    {
        this.productId = productId;
        this.quantity = quantity;
        this.username = username;
    }
}