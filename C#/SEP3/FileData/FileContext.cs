using System.Text.Json;
using Shared;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";
    private DataContainer? dataContainer;

    public ICollection<Customer> customers
    {
        get
        {
            LoadData();
            return dataContainer!.customers;
        }
    }

    public ICollection<Product> products
    {
        get
        {
            LoadData();
            return dataContainer!.products;
        }
    }
    
    public ICollection<Category> categories
    {
        get
        {
            LoadData();
            return dataContainer!.categories;
        }
    }
    
    private void LoadData()
    {
        if (dataContainer != null) return;
    
        if (!File.Exists(filePath))
        {
            dataContainer = new ()
            {
                customers = new List<Customer>(),
                products = new List<Product>(),
                categories = new List<Category>()
            };
            return;
        }
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }
    
    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer);
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}