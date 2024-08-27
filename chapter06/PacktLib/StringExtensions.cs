using System.Text.RegularExpressions;

namespace Packt.Shared;

#region Extending .NET Types
    #region Using static method

public class StringStaticMethodExtensioning
{


    public static bool IsValidEmailStatic(string input)
    {
        return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
    }

}
#endregion

public static class StringExtensionMethodExtensioning
{
     // appears to be a method just like all the actual instance methods of the string type
     // Extension methods cannot replace or override existing instance methods.
    public static bool IsValidEmailExtension(this string input)
    {
        return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
    }
}

#endregion
