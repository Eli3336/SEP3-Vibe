namespace Shared.DTOs;

public class OrderItemUpdateDto
{
    public long id { get; set; }
    public int? quantity { get; set; }
    
    public bool hasBeenBought { get; set; }
    
    public string username { get; set; }

    public OrderItemUpdateDto(long id)
    {
        this.id = id;
    }
    
    public OrderItemUpdateDto(long id, string username)
    {
        this.id = id;
        this.username = username;
    }
    
    public OrderItemUpdateDto(){}
    
    public OrderItemUpdateDto(long id, int quantity, bool hasBeenBought, string username)
    {
        this.id = id;
        this.quantity = quantity;
        this.hasBeenBought = hasBeenBought;
        this.username = username;
    }
}