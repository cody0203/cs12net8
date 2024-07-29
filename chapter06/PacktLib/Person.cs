namespace Packt.Shared;

public class Person
{
    #region Properties
    public string? Name { get; set; }
    public DateTimeOffset Born { get; set; }
    public List<Person> Children = new();
    #endregion

    #region Methods
    public void WriteToConsole()
    {
        WriteLine($"{Name} as born on a {Born:dddd}");
    }

    public void WriteChildrenToConsole()
    {
        string term = Children.Count > 1 ? "child" : "children";
        WriteLine($"{Name} has {Children.Count} {term}");
    }
    #endregion
}