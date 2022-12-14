using System.Net.Http.Json;
using System.Text;
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


    public async Task SaveEditAsync(long id, string? name, string? description, double? price, string? image, string? ingredients, string? categoryName)
    {
        ProductAdminUpdateDto product = new ProductAdminUpdateDto(id, name, description, price, image, ingredients, categoryName);
        string dtoAsJson = JsonSerializer.Serialize(product);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PatchAsync("/Product", body);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
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
    public async Task<ICollection<ProductDto>> GetSearchAsync(string? search)
    {
        HttpResponseMessage response = await client.GetAsync($"/Product/{search}" );
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<ProductDto> products = JsonSerializer.Deserialize<ICollection<ProductDto>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return products;
    }
    
    public async Task<ProductDto> GetDtoByIdAsync(long? id)
    {
        HttpResponseMessage response = await client.GetAsync($"/Product/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ProductDto post = JsonSerializer.Deserialize<ProductDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
    
    public async Task<ProductAdminUpdateDto> GetUpdateDtoByIdAsync(long? id)
    {
        HttpResponseMessage response = await client.GetAsync($"/Product/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        Product product = JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        ProductAdminUpdateDto post = new ProductAdminUpdateDto(product.id, product.name, product.description,
            product.price, product.image, product.ingredients, product.category.name);
        return post;
    }

    public async Task<Product> GetByIdAsync(long? id)
    {
        HttpResponseMessage response = await client.GetAsync($"/Product/{id}");
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            Product post = JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return post;
    }
    
    public async Task UpdateAsync(ProductUpdateDto product)
    {
        string dtoAsJson = JsonSerializer.Serialize(product);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PatchAsync("/Stock", body);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
    
    private static string ConstructQuery(string? nameContains)
    {
        string query = "";
        
        if (!string.IsNullOrEmpty(nameContains))
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query = $"toSearch={nameContains}";
        }

        return query;
    }

    public async Task<Product> GetProductById(long id)
    {
        HttpResponseMessage response = await client.GetAsync($"/Product/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        Product post = JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }

    public async Task<String> CreateAdminOrderAsync(Product product)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/OrderAdminProduct", product);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        return content;
    }


}