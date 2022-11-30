namespace Shared;

public class Purchase
{
    public long id { get; set; }
    public Order order { get; set; }
    
    public double finalPrice { get; set; } 
    
    public User user { get; set;}

    public Purchase(User user, Order order, double finalPrice)
    {
        this.finalPrice = finalPrice;
        this.order = order;
        this.user = user;
    }

    private Purchase(){}


}