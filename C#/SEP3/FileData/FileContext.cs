using System.Text.Json;
using Shared;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";
    private DataContainer? dataContainer;

    public ICollection<Customer> Customers
    {
        get
        {
            LoadData();
            return dataContainer!.Customers;
        }
    }

    public ICollection<Product> Products
    {
        get
        {
            LoadData();
            return dataContainer!.Products;
        }
    }
    
    public ICollection<Category> Categories
    {
        get
        {
            LoadData();
            return dataContainer!.Categories;
        }
    }
    
    private void LoadData()
    {
        if (dataContainer != null) return;
    
        if (!File.Exists(filePath))
        {
            dataContainer = new ()
            {
                Customers = new List<Customer>(),
                Products = new List<Product>(),
                Categories = new List<Category>()
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