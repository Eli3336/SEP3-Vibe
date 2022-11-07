namespace Shared.DTOs;

public class OrderItemCreationDto
{
    public Product Product { get;}
    public int Quantity{ get;}
    public double Price{ get;}

    public OrderItemCreationDto(Product product, int quantity, double price)
    {
        Product = product;
        Quantity = quantity;
        Price = price;
    }
}