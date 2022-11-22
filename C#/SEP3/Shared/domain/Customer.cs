namespace Shared;

public class Customer
{
    private string nameC { get; set; }
    private string phoneNumber { get; set; }
    private string username { get; set; }
    private string password { get; set; }

    private ShoppingCart shoppingCart;

    public Customer(string nameC, string phoneNumber, string username, string password, ShoppingCart shoppingCart)
    {
        this.nameC = nameC;
        this.phoneNumber = phoneNumber;
        this.username = username;
        this.password = password;
        this.shoppingCart = shoppingCart;
    }
    
    
}