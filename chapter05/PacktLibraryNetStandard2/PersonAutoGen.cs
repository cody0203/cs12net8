using System.ComponentModel;

namespace Packt.Shared;

// This file simulates an auto-generated class.

public partial class Person
{
    #region Properties: Methods to get and/or set data or state.

    // A readonly property defined using C#1 -> 5 syntax.
    public string Origin
    {
        get
        {
            return $"{Name} was born on {HomePlanet}";
        }
    }

    // Two readonly properties defined using C#6 and later
    // lambda expression body syntax
    public string Greeting => $"{Name} say 'Hello!'";

    public int Age => DateTime.Today.Year - Born.Year;

    // A read-write property defined using C#3 auto-syntax.
    public string? FavoriteIceCream { get; set; }

    // A private backing field
    private string _favoritePrimaryColor;

    // And a public property to read and write to the field
    public string? FavoritePrimaryColor
    {
        get
        {
            return _favoritePrimaryColor;
        }
        set
        {
            _SetPrimaryColor(value);
        }
    }


    private void _SetPrimaryColor(string? value)
    {
        _ = value?.ToLower() switch
        {
            "red" or "green" or "blue" => _favoritePrimaryColor = value,
            _ => throw new ArgumentException($"{value} is not a primary color. Choose from: red, blue, green.")
        };
    }

    private WondersOfTheAncientWorld _favoriteAncientWonder;

    public WondersOfTheAncientWorld FavoriteAncientWonder
    {
        get
        {
            return _favoriteAncientWonder;
        }
        set
        {
            _SetFavoriteAncientWorld(value);
        }
    }

    private void _SetFavoriteAncientWorld(WondersOfTheAncientWorld value)
    {
        string wonderName = value.ToString();

        if (wonderName.Contains(','))
        {
            throw new ArgumentException(
                message: "Favorite ancient wonder can only have a single enum value.",
                paramName: nameof(FavoriteAncientWonder)
                );
        }

        if (!Enum.IsDefined(typeof(WondersOfTheAncientWorld), value))
        {
            throw new ArgumentException(
                message: $"{value} is not a member of WondersOfTheAncientWorld enum.",
                paramName: nameof(FavoriteAncientWonder)
            );
        }

        _favoriteAncientWonder = value;
    }
    #endregion
}