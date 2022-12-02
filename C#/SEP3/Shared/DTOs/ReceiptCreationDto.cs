namespace Shared.DTOs;

public class ReceiptCreationDto
{
    public User user { get; set; }

    public Order order { get; set; }

    public ReceiptCreationDto(User user, Order order)
    {

        this.user = user;
        this.order = order;
    }
}