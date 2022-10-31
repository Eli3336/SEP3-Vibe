namespace Shared;

public class Product
{
    private long id { get; set; }
    private string name { get; set; }
    private string description { get; set; }
    private double price { get; set; }
    private Category category;

    public Product(Category category, long id, string name, string description, double price)
    {
        this.category = category;
        this.id = id;
        this.name = name;
        this.description = description;
        this.price = price;
    }
}