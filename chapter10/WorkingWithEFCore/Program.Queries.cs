using Microsoft.EntityFrameworkCore; // To use Include method.
using Northwind.EntityModels; // To use Northwind, Category, Product.
using Microsoft.EntityFrameworkCore.ChangeTracking; // To use CollectionEntry

partial class Program
{
    private static void QueryingCategories()
    {
        using NorthwindDb db = new();

        SectionTitle("Categories and how many products they have");

        // A query to get all categories and their related products.
        // IQueryable<Category>? categories = db.Categories;
        // // Calling the Include method enabled eager loading automatically.
        // // .TagWith("Categories and their products number.")
        // // .Include(c => c.Products);

        // Explicit loading entities using the Load method
        IQueryable<Category>? categories;

        db.ChangeTracker.LazyLoadingEnabled = false;

        Write("Enable eager loading (Y/N): ");
        bool eagerLoading = (ReadKey().Key == ConsoleKey.Y);
        bool explicitLoading = false;

        WriteLine();

        if (eagerLoading)
        {
            categories = db.Categories?.
            Include(c => c.Products);
        }
        else
        {
            categories = db.Categories;
            Write("Enable explicit loading? (Y/N): ");
            explicitLoading = (ReadKey().Key == ConsoleKey.Y);
            WriteLine();
        }

        if (categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return;
        }

        // 
        foreach (Category category in categories.ToList())
        {
            // With lazy loading, every time the loop enumerates an attempt is made to read the Products property
            // it will check if they are loaded. If they're not loaded, it will load them for us "lazily"
            // by executing a SELECT statement to load just that set of products for the current category.
            // => For a category and a product, it requires to execution of two SQL commands.

            if (explicitLoading)
            {
                WriteLine($"Explicitly load products for {category.CategoryName}? (Y/N): ");
                ConsoleKeyInfo key = ReadKey();
                WriteLine();

                // With explicit loading, we can control to load product or not. 
                if (key.Key == ConsoleKey.Y)
                {
                    CollectionEntry<Category, Product>products = db.Entry(category).Collection(c => c.Products);

                    if (!products.IsLoaded)
                    {
                        products.Load();
                    }
                }
            }
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

        IQueryable<Category>? categories = db.Categories?
        .TagWith("-- Categories filtered by products with a minimum number of units in stock.")
        .Include(c => c.Products.Where(p => p.Stock >= stock));

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

        IQueryable<Product>? products = db.Products?
        .TagWith("-- Products filtered by price and sorted.")
        .Where(p => p.Cost > price)
        .OrderByDescending(p => p.Cost);

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

    private static void GettingOneProduct()
    {
        using NorthwindDb db = new();

        SectionTitle("Getting a single product");

        string? input;
        int id;

        do
        {
            Write("Enter a product ID:");
            input = ReadLine();
        } while(!int.TryParse(input, out id));

        // For First, the query can match with one or more entities and only the first will be returned.
        // If there are no matches, an exception is thrown -> can using FirstOrDefault to return null if there are no matches
        Product? product = db.Products?
        // .FirstOrDefault(p => p.ProductId == id);
        .First(p => p.ProductId == id);

        Info($"First: {product?.ProductName}");

        if (product is null) Fail("No product found using First");

        // For Single, the query must match only one entity and it will be returned.
        // If there is more than one match, an exception must be thrown.
        // But the only way for EF Core to know if there is more than one match is to request more than one and check.
        // So it has set TOP(2) and check if there is a second entity match.
        product = db.Products?
        .Single(p => p.ProductId == id);

        Info($"Single: {product?.ProductName}");
        if (product is null) Fail("No product found using Single");
    }

    private static void QueryingWithLike()
    {
        using NorthwindDb db = new();

        SectionTitle("Pattern matching with LIKE");

        Write("Enter part of a product name: ");

        string? input = ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Fail("You did not enter part of a product name");
            return;
        }

        IQueryable<Product>? products = db.Products?
        .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

        if (products is null || !products.Any())
        {
            Fail("No products found.");
            return;
        }

        foreach (Product product in products)
        {
            WriteLine($"{product.ProductName} has {product.Stock} units in stock. Discontinued: {product.Discontinued}");
        }
    }
    
    private static void GetRandomProduct()
    {
        using NorthwindDb db = new();

        SectionTitle("Get a random product");

        int? rowCount = db.Products?.Count();

        if (rowCount is null)
        {
            Fail("Products table is empty");
            return;
        }

        Product? product = db.Products?
        .FirstOrDefault(p => p.ProductId == (int)(EF.Functions.Random() * rowCount));

        if (product is null)
        {
            Fail("Product not found.");
            return;
        }

        WriteLine($"Random product: {product.ProductId} - {product.ProductName}");
    }

    private static void LazyLoadingWithNoTracking()
    {
        using NorthwindDb db = new();

        SectionTitle("Lazy-loading with no tracking");
        // Should using no-tracking queries in case that we only want to get the data, and don't want to modify them.
        IQueryable<Product>? products = db.Products?.AsNoTracking();

        if (products is null || !products.Any())
        {
            Fail("No products found");
            return;
        }

        foreach (Product p in products.ToList())
        {
            WriteLine($"{p.ProductName} is in category named {p.Category.CategoryName}");
        }
    }
}