using System.Text.Json;
using BlazorClient.Services.ClientInterfaces;
using Shared;
using Shared.DTOs;

namespace BlazorClient.Services.Implementations;

public class ProductHttpClient : IProductService
{
    private readonly HttpClient client;

    public ProductHttpClient(HttpClient client)
    {
        this.client = client;
    }


    public async Task DeleteAsync(long id)
    {
        try
        {
            HttpResponseMessage response = await client.DeleteAsync($"/Product/{id}");
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
  
    public async Task<ICollection<Product>> GetAsync(string? nameContains)
    {
        try
        {
            string query = ConstructQuery(nameContains);

            HttpResponseMessage response = await client.GetAsync("/Product" + query);
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            ICollection<Product> products = JsonSerializer.Deserialize<ICollection<Product>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return products;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
    

    public async Task<ProductCreationDto> GetByIdAsync(long? id)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync($"/Product/{id}");
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            ProductCreationDto post = JsonSerializer.Deserialize<ProductCreationDto>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return post;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
    
    private static string ConstructQuery( string? nameContains)
    {
        string query = "";
        
        if (!string.IsNullOrEmpty(nameContains))
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"titleContains={nameContains}";
        }

        return query;
    }
}