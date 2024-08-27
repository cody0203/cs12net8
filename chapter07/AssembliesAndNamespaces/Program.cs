using System; // Import the System namespace with using a using statement that will fix the error below.
using Packt.Shared;

#region Relating C# keywords to .NET types
string s1 = "Hello";
String s2 = "World"; // It will be error if we remove System from csproj by <Using Remove="System" />
WriteLine($"{s1} {s2}");

#endregion

#region Understanding native-sized integers
WriteLine($"Environment.Is64BitProcess = {Environment.Is64BitProcess}");
WriteLine($"int.MaxValue = {int.MaxValue:N0}");
WriteLine($"nint.MaxValue = {nint.MaxValue:N0}");
#endregion

#region SharedLibrary as NuGet Package
Write("Enter a color value in hex:");
string? hex = ReadLine();
WriteLine($"Is {hex} a valid color value? {hex.IsValidHex()}");

Write("Enter a XML element:");
string? xmlTag = ReadLine();
WriteLine($"Is {xmlTag} a valid XML element? {xmlTag.IsValidXmlTag()}");

Write("Enter a password:");
string? password = ReadLine();
WriteLine($"Is {password} a valid password? {password.IsValidPassword()}");
#endregion