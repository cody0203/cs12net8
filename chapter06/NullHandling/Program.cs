using Packt.Shared;

#region Nullable
int thisCannotBeNull = 4;
// thisCannotBeNull = null; // Compiler error

int? thisCouldBeNull = null;

WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault()); // 0

thisCouldBeNull = 7;

WriteLine(thisCouldBeNull); // 7
WriteLine(thisCouldBeNull.GetValueOrDefault()); // 7


// The actual type of int? is Nullable<int>.
Nullable<int> thisCouldAlsoBeNull = null;
thisCouldAlsoBeNull = 9;
WriteLine(thisCouldAlsoBeNull);

#endregion

#region Nullable Reference Types
Address address = new(city: "Hanoi")
{
    Building = null,
    Street = null!, // null-forgiving operator.
    Region = "Asia"
};

WriteLine(address.Building?.Length); // Will be error without ? mark
// WriteLine(address.Street.Length); // compiler will not warning the nullable value
if (address.Street is not null)
{
    WriteLine(address.Street.Length);
}
#endregion

#region Checking For Null
if (address.Street is null)
{
    WriteLine("Street is null");
}

string authorName = null;
int? authorNameLength;
// authorNameLength = authorName.Length; // NullReferenceException
authorNameLength = authorName?.Length;
WriteLine($"Author name length: {authorNameLength}"); // null

authorNameLength = authorName?.Length ?? 25;
WriteLine($"Author name length: {authorNameLength}"); // 25
#endregion