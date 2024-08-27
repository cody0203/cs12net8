partial class Program
{
    private static void DeferredExecution(string[] names)
    {
        SectionTitle("Deferred execution");

        // Using a LINQ extension method.
        var query1 = names.Where(name => name.EndsWith('m'));

        // Answer returned as an array of strings containing Pam and Jim.
        string[] result1 = query1.ToArray();

        // Using LINQ query comprehension syntax.
        var query2 = from name in names where name.EndsWith('m') select name;

        //  Answer returned as a list of strings containing Pam and Jim.
        List<string> result2 = query2.ToList();

        foreach (string name in query1)
        {
            WriteLine(name); // outputs Pam
            names[2] = "Jimmy"; // Change Jim to Jimmy.
            // On the second iteration Jimmy does not 
            // end with an "m" so it does not get output.
        }
    }

    private static void FilteringUsingWhere(string[] names)
    {
        SectionTitle("Filtering entities using Where");

        // Explicitly creating the required delegate.
        // var query = names.Where(new Func<string, bool>(NameLongerThanFour));
        
        // The compiler creates the delegate automatically.
        // var query = names.Where(NameLongerThanFour);

        // Using a lambda expression instead of a named method.
        var query = names.Where(name => name.Length > 4);

        foreach (string item in query)
        {
            WriteLine(item);
        }
    }

    static bool NameLongerThanFour(string name)
    {
        return name.Length > 4;
    }
}