using Shared;
using Shared.domain;

namespace FileData;

public class DataContainer
{
   public ICollection<Customer> Customers { get; set; }
    public ICollection<Product> Products { get; set; }
   public ICollection<Category> Categories { get; set; }
   public ICollection<OrderItem> OrderItems { get; set; }

}