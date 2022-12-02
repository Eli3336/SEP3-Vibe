using System.Net.Mime;

namespace Shared.DTOs;

public class ProductCreationDto
{
    public string name { get; } 
    public string description { get;  }
    public double price { get; }
    public int stock { get; }
    public string image { get; }
    public string ingredients { get; }


    public ProductCreationDto(string name, string description, double price, int stock, string image, string ingredients)
    {
        this.name = name;
        this.description = description;
        this.price = price;
        this.stock = stock;
        this.image = image;
        this.ingredients = ingredients;
    }
}