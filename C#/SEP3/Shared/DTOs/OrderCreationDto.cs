namespace Shared.DTOs;

public class OrderCreationDto
{
    public string address { get; }
    
    public List<long> itemsId { get; }

    public OrderCreationDto( string address, List<long> itemsId)
    {
        
        this.address = address;
        this.itemsId = itemsId;
    }
}