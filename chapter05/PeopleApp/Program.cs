using Packt.Shared;

ConfigureConsole(culture: "en-US");

Person cody = new();

cody.Name = "Cody Pham";
cody.Born = new DateTimeOffset(year: 1995, month: 3, day: 2, hour: 4, minute: 30, second: 0, offset: TimeSpan.FromHours(+7));
WriteLine($"{cody.Name} was born on {cody.Born:D}");


Person lin = new(){
    Name = "Lin Nguyen",
    Born = new DateTimeOffset(year: 1994, month: 2, day: 15, hour: 10, minute: 2, second: 0, offset: TimeSpan.FromHours(+7))
};
WriteLine($"{lin.Name} was born on {lin.Born:d}");


#region Enum

cody.FavoriteAncientWornder = WondersOfTheAcientWorld.GreatPyramidOfGiza;
cody.BucketList = WondersOfTheAcientWorld.GreatPyramidOfGiza | WondersOfTheAcientWorld.HangingGardenOfBabylon;

WriteLine($"{cody.Name}'s favorite wonder is {cody.FavoriteAncientWornder}. Its integer is {(int)cody.FavoriteAncientWornder}");
WriteLine($"{cody.Name}'s bucket list is {cody.BucketList}. Its bytes is {(byte)cody.BucketList}");

#endregion

#region List

// Works with all verions of C#
Person alfred = new();
alfred.Name = "Alfred";
cody.Children.Add(alfred);

// Works with C# 3 and later
cody.Children.Add(new Person { Name = "Mia" } );

// Works with C# 9 and later
cody.Children.Add(new() { Name = "Zoe" });

WriteLine($"{cody.Name} has {cody.Children.Count} children: ");
foreach(Person child in cody.Children)
{
    WriteLine($"> {child.Name}");
}

#endregion

#region Static

BankAccount.InterestRate = 0.12M;
cody.BankAccount = new();
cody.BankAccount.AccountName = "Mr.Cody";
cody.BankAccount.Balance = 3_000_000;
WriteLine($"{cody.BankAccount.AccountName} earned {cody.BankAccount.Balance * BankAccount.InterestRate:C} interest");

lin.BankAccount = new();
lin.BankAccount.AccountName = "Mrs.Lin";
lin.BankAccount.Balance = 10_000_000;
WriteLine($"{lin.BankAccount.AccountName} earned {lin.BankAccount.Balance * BankAccount.InterestRate:C} interest");

#endregion

#region Constant
WriteLine($"{cody.Name} is a {Person.Species}"); // be accessible via the type
#endregion

#region Readonly
WriteLine($"{cody.Name} was born on {cody.HomePlanet}");
#endregion


#region Required w Constructor
Book book = new()
{
    Isbn = "978-1803237800",
    Title = "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals"
};

WriteLine($"{book.Isbn}: {book.Title} writtern by {book.Author} has {book.PageCount:N0} pages");
#endregion

#region Constructor
Person blankPerson = new();

WriteLine($"{blankPerson.Name} of {blankPerson.HomePlanet} was created at {blankPerson.Instantiated:hh:mm:ss} on a {blankPerson.Instantiated:dddd}");

Person gunny = new(Name: "Gunny", HomePlanet: "Mars");
WriteLine($"{gunny.Name} of {gunny.HomePlanet} was created at {gunny.Instantiated:hh:mm:ss} on a {gunny.Instantiated:dddd}");
#endregion

#region Required fields with constructor
Book book2 = new(Isbn: "978-1633438620", Title: "ASP.NET Core in Action")
{
    Author = "Andrew Lock",
    PageCount = 984
};
WriteLine($"{book2.Isbn}: {book2.Title} writtern by {book2.Author} has {book2.PageCount:N0} pages");
#endregion