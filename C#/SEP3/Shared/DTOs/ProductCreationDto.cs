namespace Shared.DTOs;

public class ProductCreationDto
{
    public string name { get; } 
    public string description { get;  }
    public double price { get; }

    public ProductCreationDto( string name, string description, double price)
    {
        this.name = name;
        this.description = description;
        this.price = price;
    }
}