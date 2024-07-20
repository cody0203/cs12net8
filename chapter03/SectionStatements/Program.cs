#region If statement
using System.Security.Cryptography;

string password = "secretP4ssw0rd";

if (password.Length < 8)
{
    WriteLine("Your password is too short. Use at least 8 characters");
}
else
{
    WriteLine("Your password is strong enough");
}

#region Pattern matching

object o = "3";
int j = 4;

if (o is int i) {
    WriteLine($"{i} x {j} = {i * j}");
}
else
{
    WriteLine("o is not an int so it cannot multiply!");
}

object p = 5;

if (p is int k)
{
    WriteLine($"{k} x {j} = {k * j}");
}
else
{
    WriteLine("p is not an int so it cannot multiply!");
}

#endregion

#endregion

#region Switch statement
int number = Random.Shared.Next(minValue:1, maxValue: 7);
WriteLine($"My random number is {number}");

switch (number)
{
    case 1:
    WriteLine("One");
    break;
    case 2:
    WriteLine("Two");
    goto case 1;
    case 3:
    case 4:
    WriteLine("Three or Four");
    goto case 1;
    case 5:
    goto A_label;
    default:
    WriteLine("Default");
    break;
}

WriteLine("After end of switch");
A_label:
WriteLine($"After A_label");
#endregion

#region Pattern matching with switch statement
var animals = new Animal?[]
{
    new Cat { Name = "Karen", Born = new(year: 2022, month: 8, day: 23), IsDomestic = true, Legs = 4 },
    null,
    new Cat { Name = "Musafa", Born = new(year: 1994, month: 6, day: 12) },
    new Spider { Name = "Sid Vicious", Born = DateTime.Today, IsPoisonous = true },
    new Spider { Name = "Captain Fury", Born = DateTime.Today }
};

foreach (var animal in animals)
{
    string message;

    switch (animal)
    {
        case Cat fourLeggedCat when fourLeggedCat.Legs == 4:
        message = $"The cat named {fourLeggedCat.Name} has four legs";
        break;

        case Cat wildCat when wildCat.IsDomestic == false:
        message = $"The  non-domestic cat is named {wildCat.Name}";
        break;

        case Cat cat:
        message = $"The cat is named {cat.Name}";
        break;

        case Spider spider when spider.IsPoisonous == true:
        message = $"The {spider.Name} spider is poisonous. Run!";
        break;

        case null:
        message = "The animal is null";
        break;

        default:
        message = $"{animal.Name} is a {animal.GetType().Name}";
        break;
    }

    WriteLine($"Switch statement: {message}");
}
#endregion

#region Switch expressions (c# 8 or later)
foreach (var animal in animals)
{
    string message = animal switch
    {
        Cat fourLeggedCat when fourLeggedCat.Legs == 4
        => $"The cat named {fourLeggedCat.Name} has four legs",

        Cat wildCat when wildCat.IsDomestic == false
        => $"The non-domestic cat is named {wildCat.Name}",

        Cat cat
        => $"The cat is named {cat.Name}",
        
        Spider spider when spider.IsPoisonous == true
        => $"The {spider.Name} spider is poisonous. Run!",

        null
        => "The animal is null",
        _
        => $"{animal.Name} is a {animal.GetType().Name}"
    };

    WriteLine($"Switch expression: {message}");
}
#endregion
