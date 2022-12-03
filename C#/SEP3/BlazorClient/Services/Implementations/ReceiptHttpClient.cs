using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BlazorClient.Services.ClientInterfaces;
using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.Implementations;

public class ReceiptHttpClient : IReceiptService
{
    private readonly HttpClient client;

    public ReceiptHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<Receipt> CreateAsync(ReceiptCreationDto receiptToCreate)
    {
        string dtoAsJson = JsonSerializer.Serialize(receiptToCreate);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsJsonAsync("/PurchaseHistory", body);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Receipt purchase= JsonSerializer.Deserialize<Receipt>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return purchase;
    }

    public Task<ReceiptCreationDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Receipt>> GetAsync(long? idContains = null)
    {
        HttpResponseMessage response = await client.GetAsync("/Purchase");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Receipt> purchases = JsonSerializer.Deserialize<ICollection<Receipt>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return purchases;
    }
}