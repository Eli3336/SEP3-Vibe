namespace Shared;

public class User
{
    public int Id { get; set; }
    public string name { get; set; }
    public string phoneNumber { get; set; }
    public string username { get; set; }
    public string password { get; set; }

    public ShoppingCart shoppingCart;
    
    public User(){}

    public User(string name, string phoneNumber, string username, string password, ShoppingCart shoppingCart)
    {
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.username = username;
        this.password = password;
        this.shoppingCart = shoppingCart;
    }
    
    
}