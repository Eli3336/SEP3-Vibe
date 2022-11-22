namespace Shared;

public class Order
{
    public long Id { get; set; }
    public DateTime orderDate { get; set; }
    public double orderPrice { get; set; }
    public string address { get; set; }
    
    public List<OrderItem> items { get; set; }
    
    public Order(){}

    public Order(DateTime orderDate, double orderPrice,string address, List<OrderItem> items)
    {
        this.orderDate = orderDate;
        this.orderPrice = orderPrice;
        this.address = address;
        this.items = items;
    }
}