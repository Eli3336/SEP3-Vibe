namespace Shared.DTOs;

public class SearchCustomerParametersDto
{
    public string? UsernameContains { get; }

    public SearchCustomerParametersDto(string? usernameContains)
    {
        UsernameContains = usernameContains;
    }
}