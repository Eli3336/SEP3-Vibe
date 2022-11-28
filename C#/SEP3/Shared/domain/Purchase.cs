namespace Shared;

public class Purchase
{
    public List<OrderItem> orderItems { get; set; }
    public int userId { get; set; }
    public DateTime dateTime { get; set; }


    public Purchase(List<OrderItem> orderItems, int userId)
    {

        this.orderItems = orderItems;
        this.userId = userId;
        this.dateTime = DateTime.Now;
    }
}