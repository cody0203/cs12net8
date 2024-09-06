using Microsoft.Data.SqlClient; // To use SqlConnectionStringBuilder.
using Microsoft.EntityFrameworkCore; // To use DbContext, DbSet<T>.

namespace Northwind.EntityModels;

public class NorthwindDb : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        SqlConnectionStringBuilder builder = new();
        builder.DataSource = ".";
        builder.InitialCatalog = "Northwind";
        builder.IntegratedSecurity = true;
        builder.Encrypt = false;
        builder.TrustServerCertificate = true;

        string connection = builder.ConnectionString;
        WriteLine($"SQL Server connection: {connection}");
        
        optionsBuilder.UseSqlServer(connection);
    }
}