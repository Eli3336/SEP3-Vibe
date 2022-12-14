namespace Shared.DTOs;

public class SearchCategoryParametersDto
{
    public string? nameContains { get; set;}

    public SearchCategoryParametersDto(string? nameContains)
    {
        this.nameContains = nameContains;
    }
}