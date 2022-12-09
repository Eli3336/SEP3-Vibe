using System.Net.Mime;

namespace Shared.DTOs;

public class ProductDto
{
    public long id { get; set; }
    public string name { get; set; } 
    public string description { get; set; }
    public double price { get; set; }
    public int stock { get; set; }
    public string image { get; set; }
    public string ingredients { get; set; }
    
    public string categoryName { get; set; }

    public ProductDto(){}
    public ProductDto(long id, string name, string description, double price, int stock, string image, string ingredients, string categoryName)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.price = price;
        this.stock = stock;
        this.image = image;
        this.ingredients = ingredients;
        this.categoryName = categoryName;
    }
}