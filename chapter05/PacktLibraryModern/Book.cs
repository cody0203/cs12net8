using System.Diagnostics.CodeAnalysis;

namespace Packt.Shared;

public class Book
{
    // .Net 7 and later as well as C#11 and later
    public required string? Isbn;
    public required string? Title;

    // any verion of .Net
    public string? Author;
    public int PageCount;

    public Book() {}

    [SetsRequiredMembers]
    public Book(string? Isbn, string? Title)
    {
        this.Isbn = Isbn;
        this.Title = Title;
    }
}
