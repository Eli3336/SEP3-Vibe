namespace Shared.DTOs;

public class ProductUpdateDto
{
    public long id { get; set; }
    public int? stock { get; set; }
    
    public ProductUpdateDto(long id)
    {
        this.id = id;
    }
}