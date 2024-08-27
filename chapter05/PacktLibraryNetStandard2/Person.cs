namespace Packt.Shared;

// Default access modifier = private
public partial class Person: System.Object
{
    #region Fields: Data or state of this person
    public string? Name;
    public DateTimeOffset Born;
    // This has been moved to PersonAutoGen.cs as a property
    // public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
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

    #region Methods: Actions the type can perform
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on {Born:dddd}");
    }

    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}";
    }

    public string SayHello()
    {
        return $"{Name} say 'Hello!'";
    }

    public string SayHello(string name)
    {
        return $"{Name} say 'Hello, {name}!'";
    }

    public string OptionalParameters(int count, string command = "Run", double number = 0.0, bool active = true)
    {
        return $"command is {command}, number is {number}, active is {active}, count is {count}";
    }

    public void PassingParameters(int w, in int x, ref int y, out int z)
    {
        // out parameter cannot have a default and
        // they must be declared inside the method.
        z = 100;

        // Increment each parameter except the read-only
        w++;

        // The read-only parameter
        // x++; // Gives a compiler error.

        y++;
        z++;

        WriteLine($"In the method: w={w}, x={x}, y={y}, z={z}");
    }

    public (string, int) GetTuplesFruits()
    {
        return ("Apples", 5);
    }

    public (string Name, int Count) GetNamedTuplesFruit()
    {
        return ("Grape", 10);
    }

    // Deconstructors: Break down this object into parts

    public void Deconstruct(out string? name, out DateTimeOffset dob)
    {
        name = Name;
        dob = Born;
    }

    public void Deconstruct(out string? name, out DateTimeOffset dob, out WondersOfTheAncientWorld fav)
    {
        name = Name;
        dob = Born;
        fav = FavoriteAncientWonder;
    }

    // Local method
    public static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException($"{nameof(number)} cannot be less than zero");
        }

        return localFactorial(number);

        int localFactorial(int localNumber)
        {
            if (localNumber == 0)
            {
                return 1;
            }

            return localNumber * localFactorial(localNumber - 1);
        }
    }
    #endregion
}