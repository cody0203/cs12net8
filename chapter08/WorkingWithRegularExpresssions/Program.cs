using  System.Text.RegularExpressions;

WriteLine("Enter your age: ");
string input = ReadLine()!;

// Regex ageChecker = new(DigitsOnlyText);

// With Source Generator
Regex ageChecker = DigitsOnly();
WriteLine(ageChecker.IsMatch(input) ? "Thank you" : $"This is not a valid age: {input}");

string films = """
"Monsters, Inc.","I, Tonya","Lock, Stock and Two Smoking Barrels"
""";

// Regex csv = new(CommaSeparatorText);

// With Source Generator
Regex csv = CommaSeparator();
MatchCollection filmsSmart = csv.Matches(films);

WriteLine("Splitting with regular expression: ");
foreach (Match film in filmsSmart)
{
    WriteLine($"   {film.Groups[2].Value}");
}