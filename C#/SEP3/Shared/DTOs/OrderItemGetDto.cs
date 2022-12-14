namespace Shared.DTOs;

public class OrderItemGetDto
{
    public Product product{ get;  set;}
    public int quantity{ get; set; }
    public double price{ get; set;}
    
    public bool hasBeenBought { get; set;}
    
    public string username { get; set;}
    
    public OrderItemGetDto(){}
    public OrderItemGetDto(Product product, int quantity, double price, bool hasBeenBought, string username)
    {
        this.product = product;
        this.quantity = quantity;
        this.price = price;
        this.hasBeenBought = hasBeenBought;
        this.username = username;
    }
}