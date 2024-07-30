using Packt.Shared;

Person cody = new()
{
    Name = "Cody",
    Born = new(year: 1995, month: 3, day: 2, hour: 4, minute: 0, second: 0, offset: TimeSpan.Zero),
};

cody.WriteToConsole();

#region Implementing functionality using methods
Person lamech = new()
{
    Name = "Lamech"
};

Person adah = new()
{
    Name = "Adah"
};

Person zillah = new()
{
    Name = "Zillah"
};

// Call the instance method to marry Lamech and Adah
lamech.Marry(adah);

// Call the static method to marry Lamech and Zillah
// Person.Marry(lamech, zillah);

// Call the operator to marry Lamech and Zillah
if (lamech + zillah)
{
    WriteLine($"{lamech.Name} and {zillah.Name} successfully got married");
}

lamech.OutputSpouses();
adah.OutputSpouses();
zillah.OutputSpouses();

// Call the instance method to make a baby
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}");

// Call the static method to make a baby
Person baby2 = Person.Procreate(lamech, zillah);
baby2.Name = "Tubalcain";

// Call the operator metho to make a baby
Person baby3 = lamech * adah;
baby3.Name = "Jubal";

adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();
lamech.WriteChildrenToConsole();

for (int i = 0; i < lamech.Children.Count; i++)
{
    WriteLine($"{lamech.Name}'s child #{i} is named {lamech.Children[i].Name}");
}
#endregion

#region Types safely reusable with generics

#region Non-generic types

// Non-generic lookup collection
System.Collections.Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: cody, value: "Delta");

int key = 2; // Look up the value that has 2 as its key

WriteLine($"Key {key} has value: {lookupObject[key]}");

// Look up the value that has cody as its key
WriteLine($"Key {cody} has value: {lookupObject[cody]}");

#endregion

#region Generic types

Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");
// lookupIntString.Add(key: cody, value: "Delta"); // Compiler error

key = 3;
WriteLine($"Key {key} has value: {lookupIntString[key]}");

#endregion

#endregion

#region Delegates and Events
// Assign the method(s) to the Shout event delegate
cody.Shout += Cody_Shout;
cody.Shout += Cody_Shout_2;
cody.Poke(); // Nothing here
cody.Poke(); // Nothing here
cody.Poke(); // Event cody's angerLevel >= 3 and the Shout != null, it will raise the Shout event everytime the angerLevel incresing.
cody.Poke(); // After added another method to the Shout event deletgate, both of them will be trigged when angerLevel >= 3.
#endregion

#region Interfaces
Person?[] people =
{
    null,
    new() { Name = "Simon" },
    new() { Name = "Jenny" },
    new() { Name = "Adam" },
    new() { Name = null },
    new() { Name = "Richard" },
};

OutputPeopleNames(people, "Initial list of people: ");

// <null> Person
// Simon
// Jenny
// Adam
// <null> Name
// Richard

Array.Sort(people);
OutputPeopleNames(people, "After sorting using Person's IComparable implementation:"); // Failed for the first time while Person class didn't implement IComparable inteface

// Adam
// Jenny
// Richard
// Simon
// <null> Name
// <null> Person

Array.Sort(people, new PersonCompare());
OutputPeopleNames(people, "After sorting using PersonCompare's IComparer implementation:"); // Using separate class to comparing object by implementing IComparer interface

// Adam
// Jenny
// Simon
// Richard
// <null> Name
// <null> Person
#endregion

#region Equality Of Types

// When check the equality of two value types, .NET compares the values of those two variables on the stack
int a = 3;
int b = 3;
WriteLine($"a: {a}, b: {b}");
WriteLine($"a == b: {a == b}"); // True

// When check the equality of two reference value types, .NET compares the memory addresses of those two variable.
Person p1 = new() { Name = "Kevin" };
Person p2 = new() { Name = "Kevin" };

WriteLine($"p1: {p1}, p2: {p2}");
WriteLine($"p1.Name: {p1.Name}, p2.Name: {p2.Name}");
WriteLine($"p1 == p2: {p1 == p2}"); // False

Person p3 = p1;
WriteLine($"p3: {p3}");
WriteLine($"p3.Name: {p3.Name}");
WriteLine($"p1 == p3: {p1 == p3}"); // True

// Those variables are still equal since their Name fields are different.
p3.Name = "Kelly";
WriteLine($"p3.Name: {p3.Name}");
WriteLine($"p1 == p3: {p1 == p3}"); // True
#endregion

#region Struct Types
DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1 + dv2;

WriteLine($"({dv1.X}, {dv2.X}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

DisplacementVector dv4 = new(3, 5);
WriteLine($"dv1.Equals(dv4): {dv1.Equals(dv4)}"); // True
// WriteLine($"dv1 == dv4: {dv1 == dv4}"); // Error if DisplacementVector is a struct type, but it's ok if it is a record struct type
#endregion