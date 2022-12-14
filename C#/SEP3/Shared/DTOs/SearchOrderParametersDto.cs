namespace Shared.DTOs;

public class SearchOrderParametersDto
{
    public long? Id { get; set;}

    public SearchOrderParametersDto(long? id)
    {
        Id = id;
    }
}