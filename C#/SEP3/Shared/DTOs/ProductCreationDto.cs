namespace Shared.DTOs;

public class ProductCreationDto
{
    public long id { get;  }
    public string name { get; } 
    public string description { get;  }
    public double price { get; }

    public ProductCreationDto(long id, string name, string description, double price)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.price = price;
    }
}