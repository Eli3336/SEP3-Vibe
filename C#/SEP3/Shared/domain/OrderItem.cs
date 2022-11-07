namespace Shared;

public class OrderItem
{
    private List<Product> products;
    private int quantity;
    private double price;

    public OrderItem(List<Product> products, int quantity, double price)
    {
        this.products = products;
        this.quantity = quantity;
        this.price = price;
    }
    
    
}