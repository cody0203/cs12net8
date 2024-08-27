using System.Globalization;
using System.Text;

OutputEncoding  = System.Text.Encoding.UTF8;
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

string city = "London";
#region Getting the length of a string
WriteLine($"{city} is {city.Length} characters long");
#endregion

#region Getting the characters of a string
WriteLine($"First char if {city[0]} and fourth is {city[3]}");
#endregion

#region Splitting a string
string cities = "Paris,Tehran,Chennai,Sydney,New York,Medellin";
string[] citiesArray = cities.Split(",");

WriteLine($"There are {citiesArray.Length} items in the array:");

foreach(string item in citiesArray)
{
    WriteLine($"  {item}");
}
#endregion

#region Getting part of a string
string fullName = "Alen Shore";
int indexOfTheSpace = fullName.IndexOf(" ");
string firstName = fullName.Substring(startIndex: 0, length: indexOfTheSpace);
string lastName = fullName.Substring(startIndex: indexOfTheSpace + 1);

WriteLine($"Original: {fullName}");
WriteLine($"Swapped: {lastName} {firstName}");
#endregion

#region Checking a string for content
string company = "Microsoft";
WriteLine($"Text: {company}");
WriteLine($"Start with M: {company.StartsWith('M')}, contains an N {company.Contains('N')}");
#endregion

#region Comparing string values
string text1 = "Mark";
string text2 = "MARK";

WriteLine($"text1: {text1}, text2: {text2}");

WriteLine($"Compare: {string.Compare(text1, text2)}."); // -1
WriteLine($"Compare (ignoreCase): {string.Compare(text1, text2, ignoreCase: true)}"); // 0

WriteLine($"Compare (InvariantCultureIgnoreCase): {string.Compare(text1, text2, StringComparison.InvariantCultureIgnoreCase)}"); // 0
#endregion

#region Joining, Formatting, and other string members
string recombined = string.Join(" => ", citiesArray);
WriteLine(recombined);

string fruit = "Apples";
decimal price = 0.39M;
DateTime when = DateTime.Today;

WriteLine($"Interpolated: {fruit} cost {price:C} on {when:dddd}");
WriteLine(string.Format("string.Format: {0} cost {1:C} on {2:dddd}", arg0: fruit, arg1: price, arg2: when));
WriteLine("WriteLine: {0} cost {1:C} on {2:dddd}", arg0: fruit, arg1: price, arg2: when);
#endregion

#region StringBuilder: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-8.0
// Create a string builder that expectrs to hold 50 chars, also initialize the StringBuilder with "ABC".
StringBuilder sb = new StringBuilder("ABC", 50);

// Append three chars (D, E, and F) to the and of the String Builder.
sb.Append(new char[] {'D', 'E', 'F'});

// Append a format string to the end of the StringBuilder.
sb.AppendFormat("GHI{0}{1}", "J", 'k');
WriteLine($"{sb.Length} chars: {sb.ToString()}");

// Insert a string at the beginning of the StringBuilder.
sb.Insert(0, "Alphabet: ");
sb.Replace("k", "K");
WriteLine($"{sb.Length} chars: {sb.ToString()}");
#endregion