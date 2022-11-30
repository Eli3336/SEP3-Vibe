using System.Threading.Tasks;
using Grpc.Net.Client;
using SupplierClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7121");
var client = new ShopGrpc.ShopGrpcClient(channel);
var reply = await client.OrderProductAsync(
    new ProductGrpc() { Name = "ProductClient" });
Console.WriteLine("Product Received: " + reply.ToString());
Console.WriteLine("Press any key to exit...");
Console.ReadKey();