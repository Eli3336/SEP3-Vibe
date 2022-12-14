namespace Shared.DTOs;


public class OrderCreationDto
{
    public string address { get; set; }
    
    public List<long> itemsId { get; set; }

    public double totalPrice { get; set; }

    public OrderCreationDto( string address, List<long> itemsId, double totalPrice)
    {
        
        this.address = address;
        this.itemsId = itemsId;
        this.totalPrice = totalPrice;
    }
}