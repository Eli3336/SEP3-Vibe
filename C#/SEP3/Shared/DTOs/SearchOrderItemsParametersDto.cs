namespace Shared.DTOs;

public class SearchOrderItemsParametersDto
{
    public  long? id { get; set;}

    public SearchOrderItemsParametersDto(long? id)
    {
        this.id = id;
    }
}