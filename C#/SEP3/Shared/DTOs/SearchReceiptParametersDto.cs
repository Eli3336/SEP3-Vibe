namespace Shared.DTOs;

public class SearchReceiptParametersDto
{
    public long? Id { get;set; }

    public SearchReceiptParametersDto(long? id)
    {
        Id = id;
    }
}