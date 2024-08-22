using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

public class NorthwindDb: DbContext
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string databaseFile = "Northwind.db";
        string path = Path.Combine(Environment.CurrentDirectory, databaseFile);

        string connectionString = $"Data Source={path}";
        WriteLine($"Connection: {connectionString}");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Example of using Fluent API instead of attributes
        // to limti the length of a category name to 15.
        modelBuilder.Entity<Category>()
        .Property(category => category.CategoryName)
        .IsRequired() // Not NULL
        .HasMaxLength(15);
    }
}