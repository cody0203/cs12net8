using System.Security.Permissions;
using Packt.Shared;
using Fruit = (string Name, int Count);

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

cody.FavoriteAncientWonder = WondersOfTheAncientWorld.GreatPyramidOfGiza;
cody.BucketList = WondersOfTheAncientWorld.GreatPyramidOfGiza | WondersOfTheAncientWorld.HangingGardenOfBabylon;

WriteLine($"{cody.Name}'s favorite wonder is {cody.FavoriteAncientWonder}. Its integer is {(int)cody.FavoriteAncientWonder}");
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

#region Methods
cody.WriteToConsole();
WriteLine(cody.GetOrigin());
WriteLine(cody.SayHello());
WriteLine(cody.SayHello(lin.Name));
WriteLine(cody.OptionalParameters(1));
WriteLine(cody.OptionalParameters(2, command: "Jump", number: 98.5));
WriteLine(cody.OptionalParameters(3, "Hide", active: false));

int a = 10; // as a parameter by default, its current value gets passed, not the variable itself.
int b = 20; // as an in parameter, a reference to variable gets passed into the method.
int c = 30; // as a ref parameter, a reference to variable gets passed into the method but can be changed
            // inside the method.
int d = 40; // as an out parameter, a reference to variable gets passed into the method and the value
            // gets replaced by statement inside the method.
WriteLine($"Before: a={a}, b={b}, c={c}, d={d}");
cody.PassingParameters(a, b, ref c, out d);
WriteLine($"After: a={a}, b={b}, c={c}, d={d}");

// Simplify out parameter
int e = 50;
int f = 60;
int g = 70;
WriteLine($"Before: e={e}, f={f}, g={g}, h doesn't exist yet!");
cody.PassingParameters(e, f, ref g, out int h);
WriteLine($"After: e={e}, f={f}, g={g}, h={h}");

// Tuples
(string, int) apple = cody.GetTuplesFruits();
WriteLine($"{apple.Item1}, {apple.Item2} there are");


// Without an aliased tuples type
var grape = cody.GetNamedTuplesFruit();
WriteLine($"Normal tuple: {grape.Name}, there are {grape.Count}");

// Aliasing tuples
Fruit grapeAliased = cody.GetNamedTuplesFruit();
WriteLine($"aliasing tuple: {grapeAliased.Name}, there are {grapeAliased.Count}");

// Deconstructing tuples
(string grapeName, int grapeCount) = cody.GetNamedTuplesFruit();
WriteLine($"Deconstructed tuple: {grapeName}, there are {grapeCount}");

// Tuples name inference
var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

var thing2 = (cody.Name, cody.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count}");

// Deconstructors
var (name1, dob1) = lin;
WriteLine($"Deconstructed person: {name1}, {dob1}");

var (name2, dob2, fav2) = cody;
WriteLine($"Deconstructed person: {name2}, {dob2}, {fav2}");

// Local method
int number = -1;
try
{
    WriteLine($"{number}! is {Person.Factorial(number)}");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says: {ex.Message} number was {number}");
}
#endregion

#region Properties
Person mia = new()
{
    Name = "Mia",
    Born = new(year: 2023, month: 8, day: 10, hour: 4, minute: 10, second: 0, offset: TimeSpan.FromHours(+7))
};

WriteLine($"{mia.Origin}");
WriteLine($"{mia.Greeting}");
WriteLine($"{mia.Age}");

mia.FavoriteIceCream = "Lime Mint Chocolate Chips";
WriteLine($"{mia.Name}'s favorite ice-cream flavor is {mia.FavoriteIceCream}.");

string color = "Cyan";
try
{
    mia.FavoritePrimaryColor = color;
    WriteLine($"{mia.Name}'s favorite primary color is {mia.FavoritePrimaryColor}.");
}
catch (Exception ex)
{
    WriteLine($"Tried to set {nameof(mia.FavoritePrimaryColor)} to '{color}': {ex.Message}'.");
}
#endregion

#region Indexers
lin.Children.Add(new () { Name = "Chi", Born = new(2022, 12, 24, 0, 0, 0, TimeSpan.FromHours(+7)) });
lin.Children.Add(mia);

// Get using Children list.
WriteLine($"{lin.Name}'s 1st child is {lin.Children[0].Name}");
WriteLine($"{lin.Name}'s 2nd child is {lin.Children[1].Name}");

// Get using the int indexer.
WriteLine($"{lin.Name}'s 1st child is {lin[0].Name}");
WriteLine($"{lin.Name}'s 2nd child is {lin[1].Name}");

// Get using the string indexer.
WriteLine($"{lin.Name}'s 1st child named {lin[0].Name} is {lin[lin[0].Name].Age} years old");
#endregion

#region Pattern matching with objects
Passenger[] passengers = {
    new FirstClassPassenger { AirMiles = 1_419, Name = "Susan" },
    new FirstClassPassenger { AirMiles = 17_249, Name = "Luck" },
    new BusinessClassPassenger { Name = "Jane" },
    new CoachClassPassenger { CarryOnKg = 25.7, Name = "David" },
    new CoachClassPassenger { CarryOnKg = 0, Name = "Amir" }
 };

 foreach (Passenger passenger in passengers)
 {
    decimal flightCost = passenger switch
    {
        // C#8 syntax
        // FirstClassPassenger p when p.AirMiles > 35_000 => 1_500M,
        // FirstClassPassenger p when p.AirMiles > 15_000 => 1_750M,
        // FirstClassPassenger _ => 2_000M,

        // C#9 and later syntax
        FirstClassPassenger p => p.AirMiles switch
        {
            > 35_000 => 1_500M,
            > 15_000 => 1_750M,
            _ => 2_000M
        },
        
        BusinessClassPassenger _ => 1_000M,
        CoachClassPassenger p when p.CarryOnKg < 10.0 => 500M,
        CoachClassPassenger _ => 650M,
        _ => 800M
    };

    WriteLine($"Flight costs {flightCost:C} for {passenger}");
 }
#endregion

#region Record Types
ImmutablePerson jeff = new()
{
    FirstName = "Jeff",
    LastName = "Winger",
};

// jeff.FirstName = "Geoff"; // Error

ImmutableVehicle car = new()
{
    Brand = "Mazda MX-5 RF",
    Color = "Soul Red",
    Wheels = 4,
};

ImmutableVehicle repaintedCar = car with
{
    Color = "Polymetal Grey",
};

WriteLine($"Original car color was {car.Color}");
WriteLine($"New car color is {repaintedCar.Color}");

AnimalClass ac1 = new()
{
    Name = "Rex"
};

AnimalClass ac2 = new()
{
    Name = "Rex"
};

WriteLine($"ac1 == ac2: {ac1 == ac2}"); // False. Class instances are only equal if their memory addresses are equal.

AnimalRecord ar1 = new()
{
    Name = "Rex"
};

AnimalRecord ar2 = new()
{
    Name = "Rex"
};

WriteLine($"ar1 == ar2 {ar1 == ar2}"); // True. Record instances are equal if they have the same property values.

ImmutableAnimal oscar = new("Oscar", "Labrador");
var (who, what) = oscar; // Calls the desconstruct method.

WriteLine($"{who} is a {what}");

#endregion

#region Primary Constructor
Headset vp = new()
{
    ProductName = "Vision Pro",
    Manualfacturer = "Apple"
};
WriteLine($"{vp.ProductName} is made by {vp.Manualfacturer}");

Headset holo = new();
WriteLine($"{holo.ProductName} is made by {holo.Manualfacturer}");
#endregion