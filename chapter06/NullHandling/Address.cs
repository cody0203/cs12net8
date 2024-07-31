namespace Packt.Shared;

public class Address
{
    public string? Building;
    public string Street = string.Empty;
    public string City;
    public string Region;

    // Call the default parameterless constructor
    // to enser that Region is also set.
    public Address()
    {
        City = string.Empty;
        Region = string.Empty;
    }

    public Address(string city) : this()
    {
        City = city;
    }

    public void ChangeAddress(string city, string region, string street, string building)
    {
        ArgumentNullException.ThrowIfNull(city);
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(street);
        ArgumentNullException.ThrowIfNull(building);
    }
}