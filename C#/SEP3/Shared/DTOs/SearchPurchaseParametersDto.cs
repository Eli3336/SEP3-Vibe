namespace Shared.DTOs;

public class SearchPurchaseParametersDto
{
    public long? Id { get; }

    public SearchPurchaseParametersDto(long? id)
    {
        Id = id;
    }
}