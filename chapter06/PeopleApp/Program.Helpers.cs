using Packt.Shared;

partial class Program
{
    private static void OutputPeopleNames(IEnumerable<Person>? people, string title)
    {
        WriteLine(title);
        foreach (Person? person in people)
        {
            WriteLine("   {0}", person is null ? "<null> Person" : person.Name ?? "<null> Name");
        }
    }
}