namespace Shared;

public class Customer
{
    private string name { get; set; }
    private string phoneNumber { get; set; }
    private string username { get; set; }
    private string password { get; set; }

    private ShoppingCart shoppingCart;

    public Customer(string name, string phoneNumber, string username, string password, ShoppingCart shoppingCart)
    {
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.username = username;
        this.password = password;
        this.shoppingCart = shoppingCart;
    }
    
    
}