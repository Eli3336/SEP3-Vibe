namespace Shared.DTOs;

public class OrderItemGetDto
{
    public Product product{ get;  }
    public int quantity{ get;  }
    public double price{ get; }
    
    public bool hasBeenBought { get; }
    

    public OrderItemGetDto(Product product, int quantity, double price, bool hasBeenBought)
    {
        this.product = product;
        this.quantity = quantity;
        this.price = price;
        this.hasBeenBought = hasBeenBought;
    }
}