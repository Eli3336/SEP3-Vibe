using System.Net.Mime;

namespace Shared.DTOs;

public class ProductDto
{
    public long id { get; }
    public string name { get; } 
    public string description { get;  }
    public double price { get; }
    public int stock { get; }
    public string image { get; }
    public string ingredients { get; }


    public ProductDto(long id, string name, string description, double price, int stock, string image, string ingredients)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.price = price;
        this.stock = stock;
        this.image = image;
        this.ingredients = ingredients;
    }
}