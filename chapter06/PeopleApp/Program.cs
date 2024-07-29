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
Person.Marry(lamech, zillah);

lamech.OutputSpouses();
adah.OutputSpouses();
zillah.OutputSpouses();

// Call the instance method to make a baby
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}");

Person baby2 = Person.Procreate(lamech, zillah);
baby2.Name = "Tubalcain";

adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();
lamech.WriteChildrenToConsole();

for (int i = 0; i < lamech.Children.Count; i++)
{
    WriteLine($"{lamech.Name}'s child #{i} is named {lamech.Children[i].Name}");
}
#endregion