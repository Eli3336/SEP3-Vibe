namespace Shared;

public class OrderItem
{
    public Product product{ get; set; }
    public int quantity{ get; set; }
    public double price{ get; set; }

    public OrderItem(Product product, int quantity, double price)
    {
        this.product = product;
        this.quantity = quantity;
        this.price = price;
    }
    
    
}