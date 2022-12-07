namespace Shared.DTOs;

public class ReceiptGetDto
{
    public User user { get; set; }

    public Order order { get; set; }

    public ReceiptGetDto(User user, Order order)
    {

        this.user = user;
        this.order = order;
    }
}