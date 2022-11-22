namespace Shared.DTOs;

public class OrderCreationDto
{
    public long Id { get; }
    public string Address { get; }

    public OrderCreationDto(long id, string address)
    {
        Id = id;
        Address = address;
    }
}