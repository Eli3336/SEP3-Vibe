namespace Shared.DTOs;

public class PurchaseCreationDto
{
    public User user { get; set; }

    public Order order { get; set; }

    public PurchaseCreationDto(User user, Order order)
    {

        this.user = user;
        this.order = order;
    }
}