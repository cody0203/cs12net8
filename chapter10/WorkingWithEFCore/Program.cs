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

LazyLoadingWithNoTracking();