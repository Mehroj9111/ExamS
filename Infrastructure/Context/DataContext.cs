using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) 
    { 
        
    }
//---------------------------------------------------------------------------------------
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<Instalment>()
        .HasOne<Customer>(s => s.Customers)
        .WithMany(g => g.Instalments)
        .HasForeignKey(s => s.CustomerId);
//------------------------------------------------
        modelBuilder.Entity<Customer>()
        .HasOne<Product>(s => s.Products)
        .WithMany(g => g.Customers)
        .HasForeignKey(s => s.ProductId);
//------------------------------------------------
        modelBuilder.Entity<Instalment>()
        .HasOne<Product>(s => s.Products)
        .WithMany(g => g.Instalments)
        .HasForeignKey(s => s.ProductId);
    }
//--------------------------------------------------
    public DbSet<Instalment> Instalments { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products {get; set;}

}