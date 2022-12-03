using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared;

namespace EfcDataAccess;

public class ShopContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Shop.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasKey(category => category.name);
        modelBuilder.Entity<Product>().HasKey(product => product.id);
        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<Receipt>().HasKey(receipt => receipt.id);
        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(orderItem => orderItem.id);
        });
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(order => order.Id);
            entity.HasMany(o => o.items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

   /* public async Task<EntityEntry<Product>> CreateProduct(Product product)
    {
        
    }
    */
}