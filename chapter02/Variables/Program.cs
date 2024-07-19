#region Storing text

#region Char

using System.Security.Principal;
using System.Xml;

char letter = 'A';
char digit = '1';
char symbol = '$';

#endregion

#region string

string firstName = "Bob";
string lastName = "Smith";
string phoneNumber = "(215) 555-4256";

// Assigning a string returned from the string class constructor

string horizontalLine = new('-', count: 74);

Console.WriteLine(horizontalLine);

// Assigning a string returned from a fictitous function

// string address = GetAddressFromDataBase(id: 563);

// Assigning an emoji by converting from Unicode
string grinningEmoji = char.ConvertFromUtf32(0x1F600);

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine(grinningEmoji);

#endregion

#region  verbamtim strings
// \t = Tab
// \n = new line
// \\ = backslash

string fullNameWithTabSeprator = "Bob\tSmith";

Console.WriteLine(fullNameWithTabSeprator);

string filePath = @"C:\televisions\sony\bravia.txt";

Console.WriteLine(filePath);

#endregion

#region Raw string literals

string xml = """
            <person age="50">
                <first_name>
                    Mark
                </first_name>
            </person>
""";

Console.WriteLine(xml);

#endregion

#region Raw interpolated string literals

var person = new {FirstName = "Alice", Age = 56};

string json = $$"""
{
    "first_name": "{{person.FirstName}}",
    "age": {{person.Age}},
    "calculation": "{{{1 + 2}}}"
}
""";

Console.WriteLine(json);

#endregion

#endregion

#region Storing numbers

// An unsigned integer is a positive whole number or 0
uint naturalNumber = 23;
uint uZero = 0;
// uint uErrorNegative = -23; Constant value '-23' cannot be converted to a 'uint'

// An integer is a positive or negative whole number or 0
int integerNumber = -23;

// A float is a single-precision floating-point number.
// the F or f suffix makes the value a float literal.
// The suffix is required to  compile
float realNumber = 2.3f;

Console.WriteLine(realNumber);

// A double is a double-precision floating-number.
// double is the default for a number value with a decimal point

double anotherRealNumber = 2.3;

Console.WriteLine(anotherRealNumber);

#region Whole numbers

int decimalNotation = 2_000_000;
int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
int hexadecimalNotation = 0x_001E_8480;

Console.WriteLine($"{decimalNotation == binaryNotation}");
Console.WriteLine($"{decimalNotation == hexadecimalNotation}");

// Output the variable values in decimal
Console.WriteLine($"{decimalNotation:N0}");
Console.WriteLine($"{binaryNotation:N0}");
Console.WriteLine($"{hexadecimalNotation:N0}");

// Output the variable values in binary
Console.WriteLine($"{decimalNotation:B}");
Console.WriteLine($"{binaryNotation:B}");
Console.WriteLine($"{hexadecimalNotation:B}");

// Output the variable values in hexadecimal
Console.WriteLine($"{decimalNotation:X}");
Console.WriteLine($"{binaryNotation:X}");
Console.WriteLine($"{hexadecimalNotation:X}");

#endregion

#region Number sizes

Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}");

Console.WriteLine(horizontalLine);

Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}");

Console.WriteLine(horizontalLine);

Console.WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}");

#endregion

#region Comparing double and decimal types

Console.WriteLine("Using doubles:");
double a = 0.1;
double b = 0.2;

if (a + b == 0.3)
{
    Console.WriteLine($"{a} + {b} equals {0.3}");
}
else
{
    Console.WriteLine($"{a} + {b} does NOT equals {0.3}"); // True
}

Console.WriteLine("Using decimals:");
decimal c = 0.1M;
decimal d = 0.2M;

if (c + d == 0.3M)
{
    Console.WriteLine($"{c} + {d} equals {0.3M}"); // True
}
else
{
    Console.WriteLine($"{c} + {d} does NOT equals {0.3M}");   
}

// Note:
// Use int for whole numbers
// Use double for real numbers that will not be compared for equality to other values
// Use decimal for money, CAD drawings, and more ...

#endregion

#region New number types and unsafe code

unsafe
{
    Console.WriteLine($"Half size uses {sizeof(Half)} bytes and can store numbers in the range {Half.MinValue:N0} to {Half.MaxValue:N0}");
    Console.WriteLine(horizontalLine);
    Console.WriteLine($"Int128 size uses {sizeof(Int128)} bytes and can store numbers in the range {Int128.MinValue:N0} to {Int128.MaxValue:N0}");
}

#endregion

#endregion

#region Storing boolens

bool happy = true;
bool sad = false;

Console.WriteLine(happy);
Console.WriteLine(sad);

#endregion

#region Storing any type of object

object height = 1.88;
object name = "Amir";
Console.WriteLine($"{name} is {height} metres tall.");

// int length1 = name.Length; // 'object' does not contain a definition for 'Length'
int length2 = ((string)name).Length;
Console.WriteLine($"{name} hash {length2} characters");

#endregion

#region Storing dynamic types

dynamic something;

// Storing an array of int values in a dynamic variable.
// An array of any type has a Length property.
something = new[] {3, 5, 7};

Console.WriteLine($"The length of somethis is {something.Length}");

Console.WriteLine($"something is a {something.GetType()}");


// Reassign an int in a dynamic variable.
// int does not have a Length property.
something = 12;

// This compiles but will throw an exception at run-time
// Console.WriteLine($"The length of somethis is {something.Length}");

Console.WriteLine($"something is a {something.GetType()}");


// Storing a string in a dynamic variable.
// string has a Length property.
something = "Amir";

Console.WriteLine($"The length of somethis is {something.Length}");

Console.WriteLine($"something is a {something.GetType()}");

#endregion

#region The var keyword

var population = 67_000_000; // int
var weight = 1.88; // double
var price = 4.99M; // decimal
var fruit = "Apples"; // string uses double-quotes
var zLetter = 'Z'; // char uses single-quotes
var tired = true; // boolean

var xml1 = new XmlDocument(); // XmlDocument - works with C# 3 and later
XmlDocument xml2 = new XmlDocument(); // XmlDocument - works with all C# version
#endregion

#region Target-typed new
XmlDocument xml3 = new(); // XmlDocument - works with C# 9 and later

Person kim = new()
{
    BirthDate = new(1995, 03, 02)
};

List<Person> people = new()
{
    new() {BirthDate = new(1994, 03, 03)},
    new() {BirthDate = new(1992, 11, 20)},
    new() {BirthDate = new(1994, 05, 25)},
};


#endregion

#region getting and setting the default values for types

// Getting
Console.WriteLine($"default(int) = {default(int)}");
Console.WriteLine($"default(bool) = {default(bool)}");
Console.WriteLine($"default(DateTime) = {default(DateTime)}");
Console.WriteLine($"default(string) = {default(string)}");

// Setting
int number = 13;
Console.WriteLine($"number set to: {number}");
number = default;
Console.WriteLine($"number reset to its default: {number}");


#endregion

class Person
{
    public DateTime BirthDate;
}