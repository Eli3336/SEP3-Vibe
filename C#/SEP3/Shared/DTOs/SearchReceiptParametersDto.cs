namespace Shared.DTOs;

public class SearchReceiptParametersDto
{
    public long? Id { get; }

    public SearchReceiptParametersDto(long? id)
    {
        Id = id;
    }
}