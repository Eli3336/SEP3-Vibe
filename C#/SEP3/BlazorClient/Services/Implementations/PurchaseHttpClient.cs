using System.Net.Http.Json;
using System.Text.Json;
using BlazorClient.Services.ClientInterfaces;
using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.Implementations;

public class PurchaseHttpClient : IPurchaseService
{
    private readonly HttpClient client;

    public PurchaseHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<Purchase> CreateAsync(PurchaseCreationDto purchaseToCreate)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Purchases", purchaseToCreate);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Purchase purchase= JsonSerializer.Deserialize<Purchase>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return purchase;
    }

    public Task<PurchaseCreationDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Purchase>> GetAsync(long? idContains = null)
    {
        HttpResponseMessage response = await client.GetAsync("/Purchase");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Purchase> purchases = JsonSerializer.Deserialize<ICollection<Purchase>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return purchases;
    }
}