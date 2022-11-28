namespace Shared;

public class Purchase
{
    public List<OrderItem> orderItems { get; set; }
    public long userId { get; set; }
    public DateTime dateTime { get; set; }


    public Purchase(List<OrderItem> orderItems, long userId)
    {

        this.orderItems = orderItems;
        this.userId = userId;
        this.dateTime = DateTime.Now;
    }
}