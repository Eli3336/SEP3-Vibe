using System.Net.Http.Json;
using System.Text.Json;
using BlazorApp.Services.ClientInterfaces;
using Shared.DTOs;
using Shared.domain;
using Shared;

namespace BlazorApp.Services.Implementations;

public class CustomerHttpClient : ICustomerService
{
    private readonly HttpClient client;

    public CustomerHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Customer> Create(CustomerCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/users", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Customer customer = JsonSerializer.Deserialize<Customer>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return customer;
    }


}