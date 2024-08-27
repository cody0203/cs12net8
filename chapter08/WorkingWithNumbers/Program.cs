using System.Numerics; // To use BigInt

#region Working with big integers

const int width = 40;
WriteLine("ulong.MaxValue vs a 30-digit BigInteger");
WriteLine(new string('-', width));

ulong big = ulong.MaxValue;
WriteLine($"{big,width:N0}");

BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
WriteLine($"{bigger,width:N0}");

#endregion

#region Working with complex numbers
Complex c1 = new(real: 4, imaginary: 2);
Complex c2 = new(real: 3, imaginary: 7);
Complex c3 = c1 + c2;

WriteLine($"{c1} added to {c2} is {c3}");
#endregion

#region Generating random numbers
Random r = Random.Shared;

// minValue is a inclusive lower bound i.e. 1 is a possible value.
// maxValue is a exclusive upper bound i.e. 7 is not a possible value.
int dieRoll = r.Next(minValue: 1, maxValue: 7);
WriteLine($"Random die roll: {dieRoll}");

double randomReal = r.NextDouble(); // Returns 0.0 to less than 1.0.
WriteLine($"Random double: {randomReal}");

byte[] arrayOfBytes = new byte[256];
r.NextBytes(arrayOfBytes); // Fill array with 256 random bytes.

Write("Random bytes: ");
for (int i = 0; i < arrayOfBytes.Length; i ++)
{
    Write($"{arrayOfBytes[i]:X2} ");
}
WriteLine();

string[] beatles = r.GetItems(
    choices: new[] {"John", "Paul", "George", "Ringo"},
    length: 10
);

Write("Random ten beatles: ");
foreach(string beatle in beatles)
{
    Write($" {beatle}");
}

WriteLine();

r.Shuffle(beatles);
Write("Shuffled beatles: ");
foreach(string beatle in beatles)
{
    Write($" {beatle}");
}

WriteLine();

WriteLine($"Empty GUID: {Guid.Empty}");
Guid g = Guid.NewGuid();
WriteLine($"Random GUID: {g}");

byte[] guidAsBytes = g.ToByteArray();
Write("GUID as byte array: ");
for (int i = 0; i < guidAsBytes.Length; i ++)
{
    Write($"{guidAsBytes[i]:X2} ");
}
WriteLine();
#endregion