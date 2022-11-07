namespace Shared.DTOs;

public class SearchOrderItemsParametersDto
{
    public  long? id { get; }

    public SearchOrderItemsParametersDto(long? id)
    {
        this.id = id;
    }
}