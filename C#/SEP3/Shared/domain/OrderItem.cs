namespace Shared;

public class OrderItem
{
    public List<Product> products;
    public int quantity;
    public double price;

    public OrderItem(List<Product> products, int quantity, double price)
    {
        this.products = products;
        this.quantity = quantity;
        this.price = price;
    }
    
    
}