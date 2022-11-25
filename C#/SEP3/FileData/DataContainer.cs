using Shared;

namespace FileData;

public class DataContainer
{
   public ICollection<User> Users { get; set; }
    public ICollection<Product> Products { get; set; }
   public ICollection<Category> Categories { get; set; }
   public ICollection<OrderItem> OrderItems { get; set; }
   public ICollection<Order> Orders { get; set; }

}