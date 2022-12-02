namespace Shared.DTOs;

public class SearchCategoryParametersDto
{
    public string? nameContains { get; }

    public SearchCategoryParametersDto(string? nameContains)
    {
        this.nameContains = nameContains;
    }
}