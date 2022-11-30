namespace Shared;

public class Purchase
{
    public Order order { get; set; }
    public long userId { get; set; }
    public double finalPrice { get; set; }


    public Purchase(long userId, Order order)
    {

        this.order = order;
        this.userId = userId;

    }

    
}