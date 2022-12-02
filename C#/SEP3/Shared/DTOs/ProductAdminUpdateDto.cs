namespace Shared.DTOs;

public class ProductAdminUpdateDto
{
    public long id { get; set; }
    public string? name { get; set; }
    public string? description { get; set; }
    public double? price { get; set; }
    public string? image { get; set; }
    public string? ingredients { get; set; }
    
    public ProductAdminUpdateDto(long id)
    {
        this.id = id;
    }
}