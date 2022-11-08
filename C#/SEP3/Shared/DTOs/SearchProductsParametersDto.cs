namespace Shared.DTOs;

public class SearchProductsParametersDto
{
    public  string? nameContains { get; }

    public SearchProductsParametersDto(string? nameContains)
    {
        this.nameContains = nameContains;
    }
}