namespace Shared.DTOs;

public class OrderItemGetDto
{
    public Product product{ get;  }
    public int quantity{ get;  }
    public double price{ get; }
    

    public OrderItemGetDto(Product product, int quantity, double price)
    {
        this.product = product;
        this.quantity = quantity;
        this.price = price;
    }
}