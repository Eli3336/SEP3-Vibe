namespace Shared.DTOs;

public class SearchProductParametersDto
{
    public long? Id { get; }

    public SearchProductParametersDto(long? id)
    {
        Id = id;
    }
}