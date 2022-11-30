namespace Shared;

public class Product
{
    public long id { get; set; }
    public string name { get; set; } 
    public string description { get; set; }
    public double price { get; set; }
    public int stock { get; set; }
   // public Category category;
   public Product(long id, string name, string description, double price, int stock)
   {
       this.id = id;
       this.name = name;
       this.description = description;
       this.price = price;
       this.stock = stock;
   }

   public Product()
   {
   }
}