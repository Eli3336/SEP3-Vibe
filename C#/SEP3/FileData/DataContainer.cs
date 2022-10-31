using Shared;

namespace FileData;

public class DataContainer
{
    public ICollection<Customer> customers { get; set; }
    public ICollection<Product> products { get; set; }
    public ICollection<Category> categories { get; set; }

}