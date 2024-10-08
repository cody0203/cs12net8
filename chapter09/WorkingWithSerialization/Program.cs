﻿using System.Xml.Serialization;
using Packt.Shared;
using FastJson = System.Text.Json.JsonSerializer;

List<Person> people = new()
{
    new(initialSalary: 30_000M)
    {
        FirstName = "Alice",
        LastName = "Smith",
        DateOfBirth = new DateTime(year: 1994, month: 2, day: 5)
    },
    new(initialSalary: 40_000M)
    {
        FirstName = "Bob",
        LastName = "Jones",
        DateOfBirth = new DateTime(year: 1987, month: 11, day: 10)
    },
    new(initialSalary: 20_000M)
    {
        FirstName = "Charlie",
        LastName = "Cox",
        DateOfBirth = new DateTime(year: 1995, month: 3, day: 5),
        Children = new()
        {
            new(initialSalary: 0M)
            {
                FirstName = "Sally",
                LastName = "Cox",
                DateOfBirth = new DateTime(year: 2023, month: 9, day: 20)
            }
        }
    }
};

#region Serializating as XML
XmlSerializer xs = new(type: people.GetType());

string path = Combine(CurrentDirectory, "people.xml");

using (FileStream stream = File.Create(path))
{
    xs.Serialize(stream, people);
}

OutputFileInfo(path);
#endregion

#region Deserializing XML files
using (FileStream xmlLoad = File.Open(path, FileMode.Open))
{
    // Deserialize and cast the object graph into a "List of Person".
    List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;

    if (loadedPeople is not null)
    {
        foreach (Person person in loadedPeople)
        {
            WriteLine($"{person.LastName} has {person.Children?.Count ?? 0} children");
        }
    }
}
#endregion

#region Serializing as JSON
SectionTitle("Serializing as JSON");
string jsonPath = Combine(CurrentDirectory, "people.json");

using (StreamWriter jsonStream = File.CreateText(jsonPath))
{
    Newtonsoft.Json.JsonSerializer jss = new();

    jss.Serialize(jsonStream, people);
}

OutputFileInfo(jsonPath);
#endregion

#region Deserializing JSON files
SectionTitle("Deserializing JSON files");
await using(FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
{
    List<Person>? loadedPeople = await FastJson.DeserializeAsync(utf8Json: jsonLoad, returnType: typeof(List<Person>)) as List<Person>;

    if (loadedPeople is not null)
    {
        foreach (Person person in loadedPeople)
        {
            WriteLine($"{person.LastName} has {person.Children?.Count ?? 0} children");
        }
    }
    
}
#endregion