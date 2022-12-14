namespace Shared.DTOs;

public class SearchUserParametersDto
{
    public string? UsernameContains { get;set; }

    public SearchUserParametersDto(string? usernameContains)
    {
        UsernameContains = usernameContains;
    }
}