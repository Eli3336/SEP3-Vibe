namespace Shared.DTOs;

public class OrderItemGetDto
{
    public Product product{ get;  }
    public int quantity{ get;  }
    public double price{ get; }
    
    public bool hasBeenBought { get; }
    
    public string username { get; }
    
    public OrderItemGetDto(){}
    public OrderItemGetDto(Product product, int quantity, double price, bool hasBeenBought, string username)
    {
        this.product = product;
        this.quantity = quantity;
        this.price = price;
        this.hasBeenBought = hasBeenBought;
        this.username = username;
    }
}