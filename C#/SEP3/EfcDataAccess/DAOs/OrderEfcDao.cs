using Grpc.Net.Client;
using GrpcClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;


namespace EfcDataAccess.DAOs;

public class OrderEfcDao : IOrderDao
{
    private readonly ShopContext context;
    private readonly GrpcChannel Channel = GrpcChannel.ForAddress("http://localhost:6566");
    private ShopGrpc.ShopGrpcClient ClientOrder;

    public OrderEfcDao(ShopContext context)
    {
        this.context = context;

        ClientOrder = new(Channel);
    }

    public async Task<Order> CreateAsync(Order order)
    {
        EntityEntry<Order> newOrder = await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return newOrder.Entity;
    }

    public async Task<Order?> GetByIdAsync(long id)
    {
        Order? existing = await context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        return existing;
    }

    public async Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto? searchParameters)
    {
        IQueryable<Order> ordersQuery = context.Orders.AsQueryable();
        if (searchParameters.Id != null)
        {
            ordersQuery = ordersQuery.Where(o => o.Id == searchParameters.Id);
        }

        IEnumerable<Order> result = await ordersQuery.ToListAsync();
        return result;
    }
}