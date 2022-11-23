using System.Net.Http.Json;
using System.Text.Json;
using BlazorClient.Services.ClientInterfaces;
using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.Implementations;

public class OrderHttpClient : IOrderService
{
    private readonly HttpClient client;

    public OrderHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Order> CreateAsync(OrderCreationDto orderToCreate)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/OrderItems", orderToCreate);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Order order = JsonSerializer.Deserialize<Order>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return order;
    }

    public Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto? searchParameters)
    {
        throw new NotImplementedException();
    }
}