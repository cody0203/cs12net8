using Northwind.EntityModels; // To use NorthwindDb, Category, Product.
using Microsoft.EntityFrameworkCore; // To use DbSet<T>.

partial class Program
{
    private static void FilterAndSort()
    {
        SectionTitle("Filter and sort");

        using NorthwindDb db = new();

        DbSet<Product> allProducts = db.Products;

        #region  With Linq extension methods
        // IQueryable<Product> filteredProducts = allProducts.Where(product => product.UnitPrice < 10M);

        // IOrderedQueryable<Product> sortedAndFilteredProducts = filteredProducts.OrderByDescending(product => product.UnitPrice);

        #endregion

        #region With Linq syntactic sugar
        IQueryable<Product> sortedAndFilteredProducts = from product in allProducts
        where product.UnitPrice < 10M
        orderby product.UnitPrice descending
        select product;

        #endregion

        // WriteLine("Products that cost less than $10:");
        // WriteLine(sortedAndFilteredProducts.ToQueryString());
        // Linq expressions will be converted into query language

        // SELECT [p].[ProductId], [p].[CategoryId], [p].[Discontinued], [p].[ProductName], [p].[QuantityPerUnit], [p].[ReorderLevel], [p].[SupplierId], [p].[UnitPrice], [p].[UnitsInStock], [p].[UnitsOnOrder]
        // FROM [Products] AS [p]
        // WHERE [p].[UnitPrice] < 10.0
        // ORDER BY [p].[UnitPrice] DESC
        // foreach (Product p in sortedAndFilteredProducts)
        // {
        //     WriteLine("{0}: {1} costs {2:$#,##0.00}", p.ProductId, p.ProductName, p.UnitPrice);
        // }
        
        #region Projection
        var projectedProducts = sortedAndFilteredProducts.Select(product => new { // Anonymous type.
            product.ProductId,
            product.ProductName,
            product.UnitPrice,
        });

        WriteLine("Products that cost less than $10:");
        WriteLine(projectedProducts.ToQueryString());

        // With projection, SELECT expression is optimized.

        // SELECT [p].[ProductId], [p].[ProductName], [p].[UnitPrice]
        // FROM [Products] AS [p]
        // WHERE [p].[UnitPrice] < 10.0
        // ORDER BY [p].[UnitPrice] DESC


        foreach (var p in projectedProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}", p.ProductId, p.ProductName, p.UnitPrice);
        }
        #endregion

        WriteLine();
    }

    private static void JoinCategoriesAndProducts()
    {
        SectionTitle("Join categories and products");

        using NorthwindDb db = new();

        #region  With Linq extension methods
        // Join every product to its category.
        // var queryJoin = db.Categories.Join( // inner join
        //     inner: db.Products,
        //     outerKeySelector: category => category.CategoryId,
        //     innerKeySelector: product => product.CategoryId,
        //     resultSelector: (c, p) => new { c.CategoryName, p.ProductName, p.ProductId }
        // );

        #endregion

        #region With Linq syntactic sugar
        var queryJoin = from c in db.Categories
        join p in db.Products
        on c.CategoryId equals p.CategoryId
        select new { c.CategoryName, p.ProductName, p.ProductId };
        #endregion

        WriteLine(queryJoin.ToQueryString());

        // SELECT [c].[CategoryName], [p].[ProductName], [p].[ProductId]
        // FROM [Categories] AS [c]
        // INNER JOIN [Products] AS [p] ON [c].[CategoryId] = [p].[CategoryId]


        foreach (var p in queryJoin)
        {
            WriteLine($"{p.ProductId}: {p.ProductName} in {p.CategoryName}");
        }
    }

    private static void GroupJoinCategoriesAndProducts()
    {
        SectionTitle("Group join categories and products");
        using NorthwindDb db = new();

        // Group all products by their category.

        #region With Linq extension methods
        
        // var queryGroup = db.Categories.GroupJoin(
        //     inner: db.Products,
        //     outerKeySelector: category => category.CategoryId,
        //     innerKeySelector: product => product.CategoryId,
        //     resultSelector: (c, matchingProducts) => new
        //     {
        //         c.CategoryName,
        //         Products = matchingProducts.OrderBy(p => p.ProductName).Select(p => new // Select necessary fields only
        //         {
        //             p.ProductName,
        //             p.ProductId,
        //         })
        //     }
        // );

        #endregion

        #region With Linq syntactic sugar
        var queryGroup = from c in db.Categories
        join p in db.Products on c.CategoryId equals p.CategoryId into matchingProducts
        select new { c.CategoryName, Products = matchingProducts.OrderBy(p => p.ProductName).Select(p => new {
            p.ProductName,
            p.ProductId
        })};
        
        #endregion

        WriteLine(queryGroup.ToQueryString());
        // SELECT [c].[CategoryName], [c].[CategoryId], [t].[ProductName], [t].[ProductId]
        // FROM [Categories] AS [c]
        // OUTER APPLY (
        //     SELECT [p].[ProductName], [p].[ProductId]
        //     FROM [Products] AS [p]
        //     WHERE [c].[CategoryId] = [p].[CategoryId]
        // ) AS [t]
        // ORDER BY [c].[CategoryId], [t].[ProductName]


        foreach (var c in queryGroup)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count()} products.");

            foreach (var p in c.Products)
            {
                WriteLine($"   {p.ProductId}: {p.ProductName}");
            }
        }
    }

    private static void ProductsLookup()
    {
        SectionTitle("Products lookup");

        using NorthwindDb db = new();

        #region With Linq extension methods

        // Join all products to their category.
        // var productQuery = db.Categories.Join(
        //     inner: db.Products,
        //     outerKeySelector: category => category.CategoryId,
        //     innerKeySelector: product => product.CategoryId,
        //     resultSelector: (c, p) => new { c.CategoryName, Product = p }
        // );

        #endregion

        #region With Linq syntactic sugar
        var productQuery = from c in db.Categories
        join p in db.Products on c.CategoryId equals p.CategoryId
        select new { c.CategoryName, Product = p };
        #endregion

        // Group product by Linq extension method.
        // ToLookup method creates a dictionary-like data structure of key-value pairs in memory.

        ILookup<string, Product> productsLookup = productQuery.ToLookup(
            keySelector: cp => cp.CategoryName,
            elementSelector: cp => cp.Product
        );

        foreach (IGrouping<string, Product> group in productsLookup)
        {
            WriteLine($"{group.Key} has {group.Count()} products");

            foreach (Product product in group)
            {
                WriteLine($"   {product.ProductName}");
            }
        }

        Write("Enter a category name: ");
        string categoryName = ReadLine()!;
        WriteLine();
        WriteLine($"Products in {categoryName}");

        IEnumerable<Product> productsInCategory = productsLookup[categoryName];
        foreach (Product product in productsInCategory)
        {
            WriteLine($" {product.ProductName}");
        }
    }

    private static void AggregateProducts()
    {
        SectionTitle("Aggregate products");

        using NorthwindDb db = new();

        // Try to get an efficient count from EF Core DbSet<T>
        if (db.Products.TryGetNonEnumeratedCount(out int countDbSet))
        {
            WriteLine($"{"Product count from DbSset:", -25} {countDbSet,10}");
        }
        else
        {
            WriteLine("Products DbSet does not have a Count property.");
        }

        // Try to get an efficient count from a List<T>
        List<Product> products = db.Products.ToList();

        if (products.TryGetNonEnumeratedCount(out int countList))
        {
            WriteLine($"{"Product count from list:",-25} {countList,10}");
        }
        else
        {
            WriteLine("Products list does not have a Count property.");
        }

        WriteLine($"{"Product count:",-25} {db.Products.Count(),10}");
        WriteLine($"{"Discontinued product count:",-27} {db.Products.Count(product => product.Discontinued),8}");
        WriteLine($"{"Highest product price:",-25} {db.Products.Max(p => p.UnitPrice),10:$#,##0.00}");
        WriteLine($"{"Sum of units in stock:",-25} {db.Products.Sum(p => p.UnitsInStock),10:N0}");
        WriteLine($"{"Sum of units on order",-25} {db.Products.Sum(p => p.UnitsOnOrder),10:N0}");
        WriteLine($"{"Average unit price:",-25} {db.Products.Average(p => p.UnitPrice),10:$#,##0.00}");
        WriteLine($"{"Value of units in stock",-25} {db.Products.Sum(p => p.UnitPrice * p.UnitsInStock),10:$#,##0.00}");
    }

    private static void OutputTableOfProducts(Product[] products, int currentPage, int totalPages)
    {
        string line = new('-', count: 73);
        string lineHalf = new('-', count: 30)
        ;
        WriteLine(line);
        WriteLine("{0,4} {1,-40} {2,12} {3,-15}", "ID", "Product Name", "Unit Price", "Discontinued");
        WriteLine(line);

        foreach (Product p in products)
        {
            WriteLine("{0,4} {1,-40} {2,12:C} {3,-15}", p.ProductId, p.ProductName, p.UnitPrice, p.Discontinued);
        }

        WriteLine("{0} Page {1} of {2} {3}", lineHalf, currentPage + 1, totalPages + 1, lineHalf);
    }

    private static void OutputPageOfProducts(IQueryable<Product> products, int pageSize, int currentPage, int totalPages)
    {
        var pagingQuery = products.OrderBy(p => p.ProductId).Skip(currentPage * pageSize).Take(pageSize);

        Clear(); // Clear the console/screen

        SectionTitle(pagingQuery.ToQueryString());

        OutputTableOfProducts(pagingQuery.ToArray(), currentPage, totalPages);
    }

    private static void PagingProducts()
    {
        SectionTitle("Paging products");

        using NorthwindDb db = new();

        int pageSize = 10;
        int currentPage = 0;
        int productCount = db.Products.Count();
        int totalPages = productCount / pageSize;

        while(true)
        {
            OutputPageOfProducts(db.Products, pageSize, currentPage, totalPages);
            Write("Press <- to page back, pres -> to page forward, any key to exit.");

            ConsoleKey key = ReadKey().Key;

            if (key == ConsoleKey.LeftArrow)
            {
                currentPage = currentPage == 0 ? totalPages : currentPage - 1;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                currentPage = currentPage == totalPages ? 0 : currentPage + 1;
            }
            else
                break;

            WriteLine();
        }
    }
}