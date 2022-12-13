namespace Shared.DTOs;


public class OrderCreationDto
{
    public string address { get; }
    
    public List<long> itemsId { get; }

    public double totalPrice { get; }

    public OrderCreationDto( string address, List<long> itemsId, double totalPrice)
    {
        
        this.address = address;
        this.itemsId = itemsId;
        this.totalPrice = totalPrice;
    }
}