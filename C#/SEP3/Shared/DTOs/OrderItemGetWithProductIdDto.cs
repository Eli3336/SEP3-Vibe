namespace Shared.DTOs;

public class OrderItemGetWithProductIdDto
{
    public long productId{ get; set; }
    public int quantity{ get; set; }
    public double price{ get; set; }
    
    public bool hasBeenBought { get; set; }
    
    public string username { get; set; }
    
    public OrderItemGetWithProductIdDto(){}
    public OrderItemGetWithProductIdDto(long id, int quantity, double price, bool hasBeenBought, string username)
    {
        this.productId = id;
        this.quantity = quantity;
        this.price = price;
        this.hasBeenBought = hasBeenBought;
        this.username = username;
    }
}