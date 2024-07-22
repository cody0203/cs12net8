namespace Packt.Shared;

// Default access modifier = private
public class Person: System.Object
{
    #region Fields: Data or state of this person
    public string? Name;
    public DateTimeOffset Born;
    public WondersOfTheAcientWorld FavoriteAncientWornder;
    public WondersOfTheAcientWorld BucketList;
    public List<Person> Children = new();

    public BankAccount? BankAccount;

    // Constant must be a literal string, boolean, or number value
    // References will no be reflected if the value changes in the feature
    public const string Species = "Homo Sapiens";

    // A better choice than constant
    // References to the read-only is a live reference -> future changes will be correctly reflected.
    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;
    #endregion

    #region Constructors: Called when using new to instantiate a type.

    public Person()
    {
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string Name, string HomePlanet)
    {
        this.Name = Name;
        this.HomePlanet = HomePlanet;
    }
    #endregion
}