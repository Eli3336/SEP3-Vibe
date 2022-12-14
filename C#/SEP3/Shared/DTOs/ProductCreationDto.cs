using System.Net.Mime;

namespace Shared.DTOs;

public class ProductCreationDto
{
    public string name { get;set; } 
    public string description { get; set; }
    public double price { get; set;}
    public int stock { get; set;}
    public string image { get; set;}
    public string ingredients { get;set; }
    public string categoryName { get; set;}

    public ProductCreationDto(string name, string description, double price, int stock, string image, string ingredients, string categoryName)
    {
        this.name = name;
        this.description = description;
        this.price = price;
        this.stock = stock;
        this.image = image;
        this.ingredients = ingredients;
        this.categoryName = categoryName;
    }
}