using Northwind.EntityModels;

using NorthwindDb db = new();
WriteLine($"Provider: {db.Database.ProviderName}");

ConfigureConsole();

// QueryingCategories();
// FitleredIncludes();

// QueryingProducts();

// GettingOneProduct();

// QueryingWithLike();

// GetRandomProduct();

// LazyLoadingWithNoTracking();

#region Inserting entities

// var resultAdd = AddProduct(categoryId: 6, productName: "Bob's Burgers", price: 500M, stock: 72);

// if (resultAdd.affected == 1)
// {
//     WriteLine($"Add product successful with ID: {resultAdd.productId}.");
// }

// ListProducts(productIdsToHighlight: new[] { resultAdd.productId });

#endregion

#region Updating entities

// var resultUpdate = IncreaseProductPrice(productNameStartWith: "Bob", amount: 100);

// if (resultUpdate.affected == 1)
// {
//     WriteLine($"Increase price success for ID: {resultUpdate.productId}.");
// }

// ListProducts(productIdsToHighlight: new[] { resultUpdate.productId });

#endregion

#region Deleting entities
WriteLine("About to delete all products whose name starts with Bob.");
Write("Press Enter to continue or any other key to exit: ");

if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int  deleted = DeleteProduct(productNameStartWith: "Bob");
    WriteLine($"{deleted} product(s) were deleted");
}
else
{
    WriteLine("Delete was canceled.");
}
#endregion