namespace Shared.DTOs;

public class OrderItemUpdateDto
{
    public long id { get; set; }
    public long? productId { get; set; }
    public int? quantity { get; set; }

    public OrderItemUpdateDto(long id)
    {
        this.id = id;
    }
}