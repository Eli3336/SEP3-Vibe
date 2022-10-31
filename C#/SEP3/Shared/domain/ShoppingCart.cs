namespace Shared;

public class ShoppingCart
{
    private List<OrderItem> items;
    private int size;
    private double totalPrice;

    public ShoppingCart(List<OrderItem> items, int size, double totalPrice)
    {
        this.items = items;
        this.size = size;
        this.totalPrice = totalPrice;
    }
}