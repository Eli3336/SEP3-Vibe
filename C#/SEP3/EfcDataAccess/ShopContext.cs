using Microsoft.EntityFrameworkCore;
using Shared;

namespace EfcDataAccess;

public class ShopContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Shop.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(product => product.id);
        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<OrderItem>().HasKey(orderItem => orderItem.id);
        modelBuilder.Entity<Order>().HasKey(order => order.Id);
    }
}