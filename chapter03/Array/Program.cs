#region Single-dimensional array
using System.Collections;
using System.Security.Cryptography;

string[] names;

names = new string[4];

names[0] = "Cody";
names[1] = "Lin";
names[2] = "Mia";
names[3] = "Kate";

string[] names2 = { "Cody", "Lin", "Mia", "Kate" };

for (int i = 0; i < names2.Length; i ++)
{
    WriteLine($"{names2[i]} is at position {i}");
}

#endregion

#region Multiple-dimensional array

#region Declare at initialization
string[,] grid1 = {
    { "Alpha", "Beta", "Gamma", "Delta" },
    { "Anne", "Ben", "Charlie", "Doug" },
    { "Aardvark", "Bear", "Cat", "Dog" }
};

// Lower bound = lowest index
// Upper bound = highest index

WriteLine($"1st dimension, lower bound: {grid1.GetLowerBound(0)}");
WriteLine($"1st dimension, upper bound: {grid1.GetUpperBound(0)}");
WriteLine($"2nd dimension, lower bound: {grid1.GetLowerBound(1)}");
WriteLine($"2nd dimension, upper bound: {grid1.GetUpperBound(1)}");

WriteLine($"2nd dimension, 3rd value: {grid1[1, 2]}"); // Manually access into deeper dimension with [] operator

for (int row = 0; row <= grid1.GetUpperBound(0); row++)
{
    for (int col = 0; col <= grid1.GetUpperBound(1); col++)
    {
        WriteLine($"Row {row}, Column {col} of grid1: {grid1[row, col]}");
    }
}

#endregion

#region Allocate memory first

string[,] grid2 = new string[3, 4]; // 3 items in 1st dimension and 4 items in 2nd dimension
grid2[0, 0] = "Alpha";
grid2[0, 1] = "Beta";
grid2[0, 2] = "Gamma";
grid2[0, 3] = "Delta";

grid2[1, 0] = "Anne";
grid2[1, 1] = "Ben";
grid2[1, 2] = "Charlie";
grid2[1, 3] = "Doug";

grid2[2, 0] = "Aardvark";
grid2[2, 1] = "Bear";
grid2[2, 2] = "Cat";
grid2[2, 3] = "Dog";

for (int row = 0; row <= grid2.GetUpperBound(0); row++)
{
    for (int col = 0; col <= grid2.GetUpperBound(1); col++)
    {
        WriteLine($"Row {row}, Column {col} of grid2: {grid2[row, col]}");
    }
}

#endregion

#endregion

#region Jagged array
string[][] jaggedArray = 
{
    new[] { "Alpha", "Beta", "Gamma" },
    new[] { "Anne", "Ben", "Charlie", "Doug" },
    new[] { "Aardvark", "Bear" },
};

WriteLine($"Upper bound of jagged array is {jaggedArray.GetUpperBound(0)}");

for (int i = 0; i <= jaggedArray.GetUpperBound(0); i ++)
{
    WriteLine($"Upper bound of array {i} is {jaggedArray[i].GetUpperBound(0)}");
}

for (int row = 0; row <= jaggedArray.GetUpperBound(0); row ++)
{
    for (int col = 0; col <= jaggedArray[row].GetUpperBound(0); col++)
    {
        WriteLine($"Row {row}, Column {col} of jaggedArray: {jaggedArray[row][col]}");
    }
}
#endregion

#region Pattern matching with arrays
WriteLine($"{new('-', count: 72)}");

int[] emptyArray = {};
WriteLine($"{nameof(emptyArray)} is {arraySwitch(emptyArray)}"); // Empty Array.


int[] oneTwoThreeTenNumbers = { 1, 2, 3, 10 };
WriteLine($"{nameof(oneTwoThreeTenNumbers)} is {arraySwitch(oneTwoThreeTenNumbers)}"); // Contains 1, 2, any single number, 10.

int[] sequentialNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; 
WriteLine($"{nameof(sequentialNumbers)} is {arraySwitch(sequentialNumbers)}"); // Contains 1, 2, any single number, 10.

int[] oneTwoTenNumbers = { 1, 2, 10};
WriteLine($"{nameof(oneTwoTenNumbers)} is {arraySwitch(oneTwoTenNumbers)}"); // Contains 1, 2, any range including empty, 10.

int[] oneTwoNumbers = { 1, 2 };
WriteLine($"{nameof(oneTwoNumbers)} is {arraySwitch(oneTwoNumbers)}"); // Contains 1 then 2.

int[] threeNumbers = { 7, 8, 9 };
WriteLine($"{nameof(threeNumbers)} is {arraySwitch(threeNumbers)}"); // Contains 7, 8, 9.

int[] zeroSeven = { 0, 7 };

WriteLine($"{nameof(zeroSeven)} is {arraySwitch(zeroSeven)}"); // Starts with 0, then one other number.

int[] primeNumbers = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
WriteLine($"{nameof(primeNumbers)} is {arraySwitch(primeNumbers)}"); // Starts with 2, then 9 more numbers.

int[] randomNumbers = { 4, 6, 7, 1, 2, 8, 10, 12};
WriteLine($"{nameof(randomNumbers)} is {arraySwitch(randomNumbers)}"); // Any items in any order.


#endregion

static string arraySwitch(int[] values) => values switch {
    [] => "Empty Array",
    [1, 2, _, 10] => "Contains 1, 2, any single number, 10",
    [1, 2, .., 10] => "Contains 1, 2, any range including empty, 10",
    [1, 2] => "Contains 1 then 2",
    [int item1, int item2, int item3] => $"Contains {item1}, {item2}, {item3}.",
    [0, _] => "Starts with 0, then one other number.",
    [0, ..] => "Starts with 0, then any range of number.",
    [2, .. int[] others] => $"Starts with 2, then {others.Length} more numbers.",
    [..] => "Any items in any order."
};

