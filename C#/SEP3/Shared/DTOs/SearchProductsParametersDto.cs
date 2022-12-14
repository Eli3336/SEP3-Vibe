namespace Shared.DTOs;

public class SearchProductsParametersDto
{
    public  string? nameContains { get;set; }

    public SearchProductsParametersDto(string? nameContains)
    {
        this.nameContains = nameContains;
    }
}