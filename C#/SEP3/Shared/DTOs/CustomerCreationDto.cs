namespace Shared.DTOs;

public class CustomerCreationDto
{
    public string Name { get;}
    public string PhoneNumber { get; set; }
    public string UserName { get;}
    public string Password { get; set; }

    public CustomerCreationDto(string name, string phoneNumber, string username, string password)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        UserName = username;
        Password = password;
    }
}