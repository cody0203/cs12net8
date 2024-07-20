using System.Globalization;

#region Casting number

#region Implicit

int a = 10;
double b = a;
WriteLine($"a is {a}, b is {b}");

#endregion

#region Explicit

double c = 9.8;
int d = (int)c;
WriteLine($"c is {c}, d is {d}"); // d loses the .8 part

long e = 10;
int f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}");

e = long.MaxValue;
f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}");

e = 5_000_000_000;
f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}"); // overflow

#endregion

#endregion

WriteLine($"{new('-', count: 74)}");

#region Converting with System.Convert type
double g = 9.8;
int h = ToInt32(g);
WriteLine($"g is {g}, h is {h}"); // round the value up -> 10

#region Default rounding rules

double[,] doubles = {
    { 9.49, 9.5, 9.51 },
    { 10.49, 10.5, 10.51 },
    { 11.49, 11.5, 11.51 },
    { 12.49, 12.5, 12.51 },
    { -12.49, -12.5, -12.51 },
    { -11.49, -11.5, -11.51 },
    { -10.49, -10.5, -10.51 },
    { -9.49, -9.5, -9.51 },
};

WriteLine($"| double | ToInt32 | double | ToInt32 | double | ToInt32");
for (int x = 0; x <= doubles.GetUpperBound(0); x++)
{
    for (int y = 0; y <= doubles.GetUpperBound(1); y++)
    {
        Write($"| {doubles[x, y],6} | {ToInt32(doubles[x, y]), 7} ");
    }
    WriteLine("|");
}
WriteLine();

// | double | ToInt32 | double | ToInt32 | double | ToInt32
// |   9.49 |       9 |    9.5 |      10 |   9.51 |      10 |
// |  10.49 |      10 |   10.5 |      10 |  10.51 |      11 |
// |  11.49 |      11 |   11.5 |      12 |  11.51 |      12 |
// |  12.49 |      12 |   12.5 |      12 |  12.51 |      13 |
// | -12.49 |     -12 |  -12.5 |     -12 | -12.51 |     -13 |
// | -11.49 |     -11 |  -11.5 |     -12 | -11.51 |     -12 |
// | -10.49 |     -10 |  -10.5 |     -10 | -10.51 |     -11 |
// |  -9.49 |      -9 |   -9.5 |     -10 |  -9.51 |     -10 |

// Even numbers
// <= .5 - toward zero
// > .5 - away from zero

// Odd numbers
// < .5 - toward zero
// >= .5 - away from zero

#endregion

#region Control rounding rules using Round method of the Math class

foreach (double n in doubles)
{
    WriteLine($"Math.Round({n}, 0, MidpointRounding.AwayFromZero) is {Math.Round(value: n, digits: 0, mode: MidpointRounding.AwayFromZero)}");
}
// Away away from zero

#endregion

WriteLine();

#region Converting from any type to string
int number = 12;
WriteLine(number.ToString());
bool happy = true;
WriteLine(happy.ToString());
DateTime now = DateTime.Now;
WriteLine(now.ToString());
object me = new();
WriteLine(me.ToString());
#endregion

WriteLine();

#region Converting from a binary object to a string
// Use case: To transfer/store image or video without be misinterpreted by converting to base64
byte[] binaryObject = new byte[128];
Random.Shared.NextBytes(binaryObject);
WriteLine("Binary object as bytes");
for (int i = 0; i < binaryObject.Length; i++)
{
    Write($"{binaryObject[i]:X2}");
}

WriteLine();

string encoded = ToBase64String(binaryObject);
WriteLine($"Binary Object as Base64: {encoded}");
#endregion

#endregion

WriteLine();

#region Parsing from string to numbers or dates and times
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

int friends = int.Parse("27");
DateTime birthday = DateTime.Parse("2 March 1995");
WriteLine($"I have {friends} friends to invite to my party");
WriteLine($"My birthday is {birthday}");
WriteLine($"My birthday is {birthday:D}");

#region TryParse

// int count = int.Parse("abc"); // System.FormatException: The input string 'abc' was not in a correct format.

int count;

if (int.TryParse("abc", out count))
{
    WriteLine($"I have {count} certificates");
}
else
{
    WriteLine("I could not parse this number");
}

#endregion

#endregion