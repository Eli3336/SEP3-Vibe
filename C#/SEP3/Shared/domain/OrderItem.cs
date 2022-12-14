using System.ComponentModel.DataAnnotations;

namespace Shared;

public class OrderItem
{
    public long id { get; set; }
    [Required]
    public Product product{ get; set; }
    public int quantity{ get; set; }
    public double price{ get; set; }
    
    public bool hasBeenBought { get; set; }
    
    public string username { get; set; }
    

    public OrderItem(Product product, int quantity, double price, bool hasBeenBought, string username)
    {
        this.product = product;
        this.quantity = quantity;
        this.price = price;
        this.hasBeenBought = hasBeenBought;
        this.username = username;
    }
    
    public OrderItem() { }

    public OrderItem(bool hasBeenBought)
    {
        this.hasBeenBought = hasBeenBought;
    }


}