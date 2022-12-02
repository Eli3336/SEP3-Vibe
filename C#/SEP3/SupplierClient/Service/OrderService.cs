using Grpc.Net.Client;

namespace SupplierClient.Service;

public class OrderService
{
    public Int64 id { get; set; }
    public string name { get; set; }
    public string description{ get; set; }
    public double price{ get; set; }
    public CategoryGrpc category{ get; set; }


    public OrderService(Int64 id, string name, string description, double price, CategoryGrpc category)
    {

        this.id = id;
        this.name = name;
        this.description = description;
        this.price = price;
        this.category = category;
    }


    public async Task<string> orderProducts(OrderService orderService)
    {
        
        using var channel = GrpcChannel.ForAddress("https://localhost:7042");
        var client = new ShopGrpc.ShopGrpcClient(channel);
        
        var reply = await client.OrderProductAsync(
            new ProductGrpc() { Id = id, Name = name, Description = description, Price = price, Category = category});


        return reply.ToString();




    }
}