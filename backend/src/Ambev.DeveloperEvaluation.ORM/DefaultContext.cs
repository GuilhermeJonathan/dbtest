using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using Ambev.DeveloperEvaluation.Domain.Entities.Products;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<ProductCart> ProductsCarts { get; set; }
    public DbSet<Sale> Sales { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.OwnsOne(e => e.Name, name =>
            {
                name.Property(n => n.Firstname).HasColumnName("Firstname");
                name.Property(n => n.Lastname).HasColumnName("Lastname");
            });

            entity.OwnsOne(e => e.Address, address =>
            {
                address.Property(a => a.City).HasColumnName("City");
                address.Property(a => a.Street).HasColumnName("Street");
                address.Property(a => a.Number).HasColumnName("Number");
                address.Property(a => a.Zipcode).HasColumnName("Zipcode");

                address.OwnsOne(a => a.Geolocation, geo =>
                {
                    geo.Property(g => g.Lat).HasColumnName("Lat");
                    geo.Property(g => g.Long).HasColumnName("Long");
                });
            });
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.OwnsOne(e => e.Rating, rating =>
            {
                rating.Property(n => n.Count).HasColumnName("Count");
                rating.Property(n => n.Rate).HasColumnName("Rate");
            });
        });

        modelBuilder.Entity<Sale>()
           .Property(e => e.Id)
           .ValueGeneratedOnAdd();
    }
}

public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseSqlite(
             connectionString,
             b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
        );

        return new DefaultContext(builder.Options);
    }
}