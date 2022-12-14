using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BlazorClient.Services.ClientInterfaces;
using Shared;
using Shared.DTOs;


namespace BlazorClient.Services.Implementations;

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

    
    public async Task DeleteAsync(long id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"OrderItems/{id}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task UpdateAsync(OrderItemUpdateDto orderItem)
    {
        string dtoAsJson = JsonSerializer.Serialize(orderItem);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PatchAsync("/OrderItems", body);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<OrderItemGetWithProductIdDto> GetByIdAsync(long id)
    {
        HttpResponseMessage response = await client.GetAsync($"/OrderItems/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        Console.WriteLine(content);

        OrderItemGetWithProductIdDto? orderItemGetWithProductIdDto =
            JsonSerializer.Deserialize<OrderItemGetWithProductIdDto>(content);
        
        Console.WriteLine("q"+orderItemGetWithProductIdDto.quantity);
        Console.WriteLine(orderItemGetWithProductIdDto.productId);
        
        return orderItemGetWithProductIdDto;
    }

    public async Task<List<OrderItem>> GetAll()
    {
        string uri = "/OrderItems";
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
        return orderItems.ToList();
    }

    public async Task SetOrderItemToBought(OrderItemUpdateDto dto)
    {
        string dtoAsJson = JsonSerializer.Serialize(dto);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PatchAsync("/Buy", body);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<IEnumerable<OrderItem>> GetNotBoughtOrderItemsByUsername(string username)
    {
        string uri = $"/NotBought/{username}";
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