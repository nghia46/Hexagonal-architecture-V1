using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Database=hexagon-db; Username=postgres; Password=Abcd1234");
    }
    public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
    }

}
