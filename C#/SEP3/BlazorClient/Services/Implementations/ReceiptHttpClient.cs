using System.Net.Http.Json;
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
    
    public async Task<Receipt> CreateAsync(ReceiptCreationDto purchaseToCreate)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Purchases", purchaseToCreate);
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