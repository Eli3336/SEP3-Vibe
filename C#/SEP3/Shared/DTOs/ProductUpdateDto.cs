namespace Shared.DTOs;

public class ProductUpdateDto
{
    public long id { get; set; }
    public int? stock { get; set; }
    
    public ProductUpdateDto(){}
    
    public ProductUpdateDto(long id)
    {
        this.id = id;
    }

    public ProductUpdateDto(long id, int stock)
    {
        this.id = id;
        this.stock = stock;
    }
}