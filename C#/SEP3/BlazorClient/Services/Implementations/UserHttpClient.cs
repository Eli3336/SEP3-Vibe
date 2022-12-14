using System.Net.Http.Json;
using System.Text.Json;
using BlazorClient.Services.ClientInterfaces;
using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<User> Create(UserCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/users", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }

    public async Task<User> GetByUsername(string username)
    {
        HttpResponseMessage response = await client.GetAsync($"/Users/{username}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        Console.WriteLine("User: " + content);

        User user = JsonSerializer.Deserialize<User>(content, 
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        )!;
        
        Console.WriteLine("User: " + user.username);
        return user;
    }
    
}