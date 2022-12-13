namespace Shared;

public class ShoppingCart
{
    public List<OrderItem> items;
    public int size;
    public double totalPrice;

    public ShoppingCart(List<OrderItem> items, int size, double totalPrice)
    {
        this.items = items;
        this.size = size;
        this.totalPrice = totalPrice;
    }
    public ShoppingCart(){}
}