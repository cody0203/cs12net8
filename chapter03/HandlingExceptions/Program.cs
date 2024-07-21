// #region Catch all exceptions
// WriteLine("Before parsing");
// Write("What is your age? ");
// string? input = ReadLine();

// // try
// // {
// //     int age = int.Parse(input!);
// //     WriteLine($"You are {age} years old.");
// // }
// // catch (Exception ex)
// // {
// //     WriteLine($"{ex.GetType()} say {ex.Message}");
// // }

// #endregion

// #region Catch specific exceptions

// try
// {
//     int age = int.Parse(input!);
//     WriteLine($"You are {age} years old.");
// }
// catch (OverflowException)
// {
//     WriteLine("Your are is a valid number but it is either too big or small.");
// }
// catch (FormatException)
// {
//     WriteLine("The age you entered is not a valid number format.");
// }
// catch (Exception ex)
// {
//     WriteLine($"{ex.GetType()} says {ex.Message}");
// }
// #endregion

// WriteLine("After parsing");

// #region Catching with filters
// Write("Enter an amount: ");
// string amount = ReadLine()!;

// if (string.IsNullOrEmpty(amount)) return;

// try
// {
//     decimal amountValue = decimal.Parse(amount);
//     WriteLine($"Amount formatted as currency: {amountValue:C}");
// }
// catch (FormatException) when (amount.Contains('$'))
// {
//     WriteLine("Amount cannot use the dollar sign!");
// }
// catch (FormatException)
// {
//     WriteLine("Amounts must only contains digits!");
// }
// #endregion

#region Checking for overflow
checked
{
    try
    {
        int x = int.MaxValue - 1;
        WriteLine($"Initial value: {x}");
        x++;
        WriteLine($"After incrementing: {x}");
        x++;
        WriteLine($"After incrementing: {x}");
        x++;
        WriteLine($"After incrementing: {x}");
    }
    catch (OverflowException)
    {
        WriteLine("The code overflow but I caught the exception");
    }
}
#endregion

#region Disabling compiler overflow checks
unchecked
{
    int y = int.MaxValue + 1;
    WriteLine($"Initial value: {y}");
    y--;
    WriteLine($"After decrementing: {y}");
    y--;
    WriteLine($"After decrementing: {y}");
}
#endregion

#region Loops and overflow

int max = 500;
checked
{
    for (byte i = 0; i < max; i++)
    {
    WriteLine(i);
    }
}

#endregion