namespace Shared;

public class Product
{
    private long id { get; set; }
    public string name { get; set; } //had to make it public for the view product page(i think everything should be public)
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