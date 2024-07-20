#region While statement

using System.Collections;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

int x = 0;

while (x < 10)
{
    WriteLine(x);
    x++;
}
#endregion

#region Do statement
string? actualPassword = "Pa$$w0rd";
string? password;

do
{
    Write("Enter your password: ");
    password = ReadLine();
}
while (password != actualPassword);

WriteLine("Correct!");
#endregion

#region For statement
for (int y = 1; y <= 10; y++)
{
    WriteLine(y);
}
#endregion

#region For each statement
string[] names = { "Adam",  "Barry", "Charlie" };

foreach (string name in names)
{
    WriteLine($"Foreach: {name} has {name.Length} characters");
}

// How foreach works behind the scene
IEnumerator e = names.GetEnumerator();

while (e.MoveNext())
{
    string name = (string)e.Current; // read-only
    WriteLine($"Foreach Behind the scene: {name} has {name.Length} characters");
}
#endregion