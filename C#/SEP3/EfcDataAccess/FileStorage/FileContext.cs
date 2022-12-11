using System.Text.Json;

namespace EfcDataAccess.FileStorage;

public class FileContext
{
    private const string filePath = "data.json";

    private DataContainer? dataContainer;

    public ICollection<string> Images
    {
        get
        {
            LazyLoadData();
            return dataContainer!.Images;
        }
    }
    private void LazyLoadData()
    {
        if (dataContainer == null)
        {
            LoadData();
        }
    }
    private void LoadData()
    {
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