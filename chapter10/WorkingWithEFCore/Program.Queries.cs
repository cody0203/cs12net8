using Microsoft.EntityFrameworkCore; // To use Include method.
using Northwind.EntityModels; // To use Northwind, Category, Product.

partial class Program
{
    private static void QueryingCategories()
    {
        using NorthwindDb db = new();

        SectionTitle("Categories and how many products they have");

        // A query to get all categories and their related products.
        IQueryable<Category>? categories = db.Categories?.Include(c => c.Products);

        if (categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return;
        }

        foreach (Category category in categories)
        {
            WriteLine($"{category.CategoryName} has {category.Products.Count} products");
        }
    }

    private static void FitleredIncludes()
    {
        using NorthwindDb db = new();

        SectionTitle("Products with a minimum number of units in stock");

        string? input;
        int stock;

        do
        {
            Write("Enter a minimum for units in stock:");
            input = ReadLine();
        } while(!int.TryParse(input, out stock));

        IQueryable<Category>? categories = db.Categories?.Include(c => c.Products.Where(p => p.Stock >= stock));

        if (categories is null || !categories.Any())
        {
            Fail("No categories found");
            return;
        }
        
        Info($"ToQueryString: {categories.ToQueryString()}");
        
        foreach (Category category in categories)
        {
            WriteLine($"{category.CategoryName} has {category.Products.Count} products with a minimum {stock} units in stock");

            foreach (Product product in category.Products)
            {
                WriteLine($"  {product.ProductName} has {product.Stock} units in stock");
            }
        }
    }

    private static void QueryingProducts()
    {
        using NorthwindDb db = new();

        SectionTitle("Products that cost more than a price, highest at top");

        string? input;
        decimal price;

        do
        {
            Write("Enter a product price:");
            input = ReadLine();
        } while(!decimal.TryParse(input, out price));

        IQueryable<Product>? products = db.Products?.Where(p => p.Cost > price).OrderByDescending(p => p.Cost);

        if (products is null || !products.Any())
        {
            Fail("No products found");
            return;
        }

        Info($"ToQueryString: {products.ToQueryString()}");

        foreach (Product product in products)
        {
            WriteLine($"{product.ProductId}: {product.ProductName} costs {product.Cost:$#,##0.00} and has {product.Stock} in stock.");
        }
    }
}