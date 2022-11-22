namespace Shared.DTOs;

public class SearchOrderParametersDto
{
    public long? Id { get; }

    public SearchOrderParametersDto(long? id)
    {
        Id = id;
    }
}