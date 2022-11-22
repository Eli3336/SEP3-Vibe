namespace Shared;

public class Order
{
    public int Id { get; set; }
    public string address { get; set; }
    
    public Order(){}

    public Order(string address)
    {
        this.address = address;
    }
}