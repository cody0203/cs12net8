using System; // Import the System namespace with using a using statement that will fix the error below.

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