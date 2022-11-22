namespace Shared.DTOs;

public class OrderCreationDto
{
    public DateTime OrderDate { get; }
    public double OrderPrice { get;  }
    public string Address { get; }
    
    public List<OrderItem> Items { get; }

    public OrderCreationDto(double orderPrice, string address, List<OrderItem> items)
    {
        OrderDate = DateTime.Now;
        OrderPrice = orderPrice;
        Address = address;
        Items = items;
    }
}