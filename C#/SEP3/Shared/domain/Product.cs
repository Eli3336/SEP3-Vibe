namespace Shared;

public class Product
{
    public long id { get; set; }
    public string name { get; set; } 
    public string description { get; set; }
    public double price { get; set; }
    public int stock { get; set; }
    public string image { get; set; }
    public string ingredients  { get; set; }
   // public Category category;
   public Product(long id, string name, string description, double price, int stock, string image, string ingredients)
   {
       this.id = id;
       this.name = name;
       this.description = description;
       this.price = price;
       this.stock = stock;
       this.image = image;
       this.ingredients = ingredients;
   } 
   public Product( string name, string description, double price, string image, string ingredients)
   {
       this.name = name;
       this.description = description;
       this.price = price;
       this.image = image;
       this.ingredients = ingredients;
   }
   

   public Product()
   {
   }
}