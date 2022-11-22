using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared;
using Shared.DTOs;


namespace HttpClients.Implementations;

public class OrderItemHttpClient : IOrderItemService
{
    private readonly HttpClient client;

    public OrderItemHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<OrderItem> OrderProduct(OrderItemCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/OrderItems", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        OrderItem orderItem = JsonSerializer.Deserialize<OrderItem>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return orderItem;
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItem(string? nameContains = null)
    {
        string uri = "/OrderItems";
        if (!string.IsNullOrEmpty(nameContains))
        {
            uri += $"?name={nameContains}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Console.WriteLine(result);
        IEnumerable<OrderItem> orderItems = JsonSerializer.Deserialize<IEnumerable<OrderItem>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return orderItems;
    }

}