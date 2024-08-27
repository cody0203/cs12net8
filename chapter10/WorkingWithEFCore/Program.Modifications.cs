using Microsoft.EntityFrameworkCore; // To use ExecuteUpdate, ExecuteDelete
using Microsoft.EntityFrameworkCore.ChangeTracking; // To use EntityEntry<T>
using Northwind.EntityModels; // To use Northwind, Product.

partial class Program
{
    private static void ListProducts(int[]? productIdsToHighlight = null)
    {
        using NorthwindDb db = new();
        
        if (db.Products is null || !db.Products.Any())
        {
            Fail("There are no products");
            return;
        }

        WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4} |", "Id", "Product Name", "Cost", "Stock", "Disc.");

        foreach (Product p in db.Products)
        {
            ConsoleColor previousColor = ForegroundColor;
            if (productIdsToHighlight is not null && productIdsToHighlight.Contains(p.ProductId))
            {
                ForegroundColor = ConsoleColor.Green;
            }
            WriteLine("| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4} |",
            p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);
            ForegroundColor = previousColor;
        }
     }

     private static (int affected, int productId) AddProduct(int categoryId, string productName, decimal? price, short? stock)
     {
        using NorthwindDb db = new();

        if (db.Products is null) return (0, 0);

        Product p = new()
        {
            CategoryId = categoryId,
            ProductName = productName,
            Stock = stock,
            Cost = price,
        };

        // Set product as added in change tracking.
        EntityEntry<Product> entity = db.Products.Add(p);
        WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

        // Save tracked change to database.
        int affected = db.SaveChanges();
        WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

        return (affected, p.ProductId);
     }

     private static (int affected, int productId) IncreaseProductPrice(string productNameStartWith, decimal amount)
     {
        using NorthwindDb db = new();
        
        if (db.Products is null) return (0, 0);

        Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(productNameStartWith));

        updateProduct.Cost += amount;

        int affected = db.SaveChanges();

        return (affected, updateProduct.ProductId);
     }
}