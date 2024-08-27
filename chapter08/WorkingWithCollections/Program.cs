using StringDictionary = System.Collections.Generic.Dictionary<string, string>;
using System.Collections.Immutable;
using System.Collections.Frozen;

# region List
List<string> cities = new();

cities.Add("London");
cities.Add("Paris");
cities.Add("Milan");

/* Alternative syntax
List<string> cities = new() { "London", "Paris", "Milan" };
*/

/* Alternative syntax
List<string> cities = new();
cities.AddRange(new[] { "London", "Paris", "Milan" });
*/

OutputCollection("Initial list", cities);
WriteLine($"The first city is {cities[0]}");

WriteLine($"The last cities is {cities[cities.Count - 1]}");
/* Alternative syntax
WriteLine($"The last cities is {cities[^1]}")
*/

cities.Insert(0, "Sydney");
OutputCollection("After inserting Sydney at index 0", cities);

cities.RemoveAt(1);
cities.Remove("Milan");
OutputCollection("After removing two cities", cities);

#endregion

#region Dictionaries
StringDictionary keywords = new();

// Add using named parameters.
keywords.Add(key: "int", value: "32-bit integer data type");

// Add using positional parameters.
keywords.Add("long", "64-bit integer data type");
keywords.Add("float", "Single precision floating point number");

/* Alternative syntax; compiler converts this to calls to Add method.
Dictionary<string, string> keywords = new()
{
    {"int", "32-bit integer data type"},
    {"long", "64-bit integer data type"},
    {"float", "Single precision floating point number"},
}; */

/* Alternative syntax; compiler converts this to calls to Add method.
Dictionary<string, string> keywords = new()
{
    ["int"] = "32-bit integer data type",
    ["long"] = "64-bit integer data type",
    ["float"] = "Single precision floating point number",
}*/

OutputCollection("Dictionary keys", keywords.Keys);
OutputCollection("Dictionary values", keywords.Values);

WriteLine("Keywords and their definitions:");
foreach (KeyValuePair<string, string> item in keywords)
{
    WriteLine($"   {item.Key}: {item.Value}");
}


// Look up a value using a key
string key = "long";
WriteLine($"The definition of {key} is {keywords[key]}");
#endregion

#region Sets
HashSet<string> names = new();

foreach (string name in new[] { "Adam", "Barry", "Charlie", "Barry"})
{
    bool added = names.Add(name);
    WriteLine($"{name} was added: {added}.");
}

WriteLine($"names set: {string.Join(",", names)}");
#endregion

#region Queue
Queue<string> coffee = new();

coffee.Enqueue("Damir"); // Front of the queue.
coffee.Enqueue("Andrea");
coffee.Enqueue("Ronald");
coffee.Enqueue("Irina"); // Back of the queue.

OutputCollection("Initial queue from front to back", coffee);

// Server handles next person in queue.
string served = coffee.Dequeue();
WriteLine($"Served: {served}");

// Server handles next person in queue.
served = coffee.Dequeue();
WriteLine($"Served: {served}");
OutputCollection("Current queue from front to back", coffee);

WriteLine($"{coffee.Peek()} is next in line");
OutputCollection("Current queue from front to back", coffee);
#endregion

#region PriorityQueue
PriorityQueue<string, int> vaccine = new();
/* Add some people.
1 = High priority people in their 70s or poor health
2 = Medium priority e.g. middle-aged.
3 = Low priority e.g. teens and twenties.
*/

vaccine.Enqueue("Pamela", 1);
vaccine.Enqueue("Rebecca", 3);
vaccine.Enqueue("Juliet", 2);
vaccine.Enqueue("Ian", 1);

OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

WriteLine($"{vaccine.Dequeue()} has been vaccinated");
WriteLine($"{vaccine.Dequeue()} has been vaccinated");
OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

WriteLine($"{vaccine.Dequeue()} has been vaccinated");

WriteLine("Adding Mark to queue with priority 2");
vaccine.Enqueue("Mark", 2);

WriteLine($"{vaccine.Peek()} will be next to tbe vaccinated");
OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);
#endregion

#region Read-only collections
// UseDictionary(keywords); // Success
// OutputCollection("Dictionary keys", keywords.Keys);
// OutputCollection("Dictionary values", keywords.Values);

// Read-only dictionary
// UseDictionary(keywords.AsReadOnly()); // Exception thrown: 'System.NotSupportedException' in System.Private.CoreLib.dll

#endregion

#region Immutable collections
// Immutable dictionary
// UseDictionary(keywords.ToImmutableDictionary()); // Exception thrown: 'System.NotSupportedException' in System.Collections.Immutable.dll

ImmutableDictionary<string, string> immutableKeywords = keywords.ToImmutableDictionary();

// The Add method returns a new list with the new item in it. Does not affect the original dictionary.
ImmutableDictionary<string, string> newDictionary = immutableKeywords.Add(
    key: Guid.NewGuid().ToString(),
    value: Guid.NewGuid().ToString()
);

OutputCollection("Immutable keywords dictionary", immutableKeywords);
OutputCollection("New keywords dictionary", newDictionary);

#endregion

#region Frozen collections
FrozenDictionary<string, string> frozenKeywords = keywords.ToFrozenDictionary();
OutputCollection("Frozen keywords dictionary", frozenKeywords);

// Lookups are after in a frozen dictionary
WriteLine($"Define long: {frozenKeywords["long"]}");

// frozenKeywords.Add(); // The Add method doesn't exist in FrozenDictionary type.
#endregion

#region Initializing collections using collection expressions
// C# 11 and earlier
int[] numbersArray11 = {1, 3, 5};
List<int> numbersList11 = new() { 1, 3, 5};
Span<int> numbersSpan11 = stackalloc int[] { 1, 3, 5};

// C# 12
int[] numbersArray12 = [ 1, 3, 5 ];
List<int> numbersList12 = [ 1, 3, 5 ];
Span<int> numbersSpan12 = [ 1, 3, 5 ];
#endregion