using Packt.Shared;
using System.Text.Json; // To use JsonSerializer.

Book csharpBook = new(title: "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals")
{
    Author = "Mark J Price",
    PublishDate = new(year: 2023, month: 11, day: 14),
    Created = DateTimeOffset.Now,
    Pages = 832,
};

JsonSerializerOptions options = new()
{
    IncludeFields = true, // Includes all fields.
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

string path = Combine(CurrentDirectory, "book.json");
using (Stream fileStream = File.Create(path))
{
    JsonSerializer.Serialize(utf8Json: fileStream, value: csharpBook);
    // With options: File's size is 222 bytes.
    // Without options: File's size is 182 bytes.
}

WriteLine("**** File Info ****");
WriteLine($"File: {GetFileName(path)}");
WriteLine($"Path: {GetDirectoryName(path)}");
WriteLine($"Size: {new FileInfo(path).Length:N0} bytes");
WriteLine("/------------------");
WriteLine(File.ReadAllText(path));
WriteLine("------------------/");