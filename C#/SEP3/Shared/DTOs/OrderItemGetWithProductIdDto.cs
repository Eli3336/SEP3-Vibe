namespace Shared.DTOs;

public class OrderItemGetWithProductIdDto
{
    public long productId{ get;  }
    public int quantity{ get;  }
    public double price{ get; }
    
    public bool hasBeenBought { get; }
    
    public string username { get; }
    
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