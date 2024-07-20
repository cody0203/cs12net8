#region Binary operators
// var resultOfOperator = firstOperand operator secondOperand;
using System.Security.Principal;

int x = 5;
int y = 3;
int resultOfAdding = x + y;
int resultOfMultiplying = x * y;
#endregion

#region Unary operators
// var resultOfOperationAfter = onlyOperand operator;
// var resultOfOperationBefore = operator onlyOperand;

int num = 5;
int postfixIncrement = num++;
int prefixIncrement = ++num;

Type theTypeOfAnInteger = typeof(int);
string nameOfVariable = nameof(num);
WriteLine(nameOfVariable);
int howManyBytesInAnInteger = sizeof(int);
#endregion

#region ternary operators
// var resultOfOperator = firstOperand firstOperator secondOperand secondOperator thirdOperand;

// var result = boolean_expression ? value_if_true : value_if_false;
string result = x > 3 ? "Greater than 3" : "Less than or equal to 3" ;
#endregion

#region Exploring binary operators
int a = 3;
int b = a++;
WriteLine($"a is {a}, b is {b}");

int c = 3;
int d = ++c;
WriteLine($"c is {c}, d is {d}");
#endregion

#region Exploring binary arithmetic operators
int e = 11;
int f = 3;

WriteLine($"e is {e}, f is {f}");
WriteLine($"e + f = {e + f}");
WriteLine($"e - f = {e - f}");
WriteLine($"e - f = {e - f}");
WriteLine($"e / f = {e / f}");
WriteLine($"e % f = {e % f}");

double g = 11.0;
WriteLine($"g is {g:N1}, f is {f}");
WriteLine($"g / f = {g / f}");
#endregion

#region Assignment operator
int p = 6;
p += 3; // p = p + 3
p -= 3; // p = p - 3
p *= 3; // p = p * 3
p /= 3; // p = p / 3

WriteLine($"p is {p}");
#endregion

#region Null-coalescing operators
string? authorName = null;
int maxLength = authorName?.Length ?? 30;
authorName ??= "unknown";
WriteLine($"authorName is {authorName}, authorName length is {maxLength}");
#endregion

#region Logical operators
bool i = true;
bool j = false;
WriteLine($"AND   |i     |j     ");
WriteLine($"i     |{i & i,-5} {i & j,-5} ");
WriteLine($"j     |{j & i,-5} {j & j,-5} ");
WriteLine();
WriteLine($"OR   |i     |j     ");
WriteLine($"i     |{i | i,-5} {i | j,-5} ");
WriteLine($"j     |{j | i,-5} {j | j,-5} ");
WriteLine();
WriteLine($"XOR   |i     |j     ");
WriteLine($"i     |{i ^ i,-5} {i ^ j,-5} ");
WriteLine($"j     |{j ^ i,-5} {j ^ j,-5} ");
#endregion

#region Exploring conditional logical operators

WriteLine();
WriteLine($"i & DoStuff() = {i & DoStuff()}"); 
WriteLine($"j & DoStuff() = {j & DoStuff()}"); 

WriteLine();
WriteLine($"i && DoStuff() = {i && DoStuff()}"); 
WriteLine($"j && DoStuff() = {j && DoStuff()}"); 

#endregion

#region Exploring bitwise and binary shifts operators
int l = 10;
int n = 6;

WriteLine($"Expression | Decimal |   Binary");
WriteLine($"-------------------------------");
WriteLine($"l          | {l,7} | {l:B8}");
WriteLine($"n          | {n,7} | {n:B8}");
WriteLine($"n & l      | {n & l,7} | {n & l:B8}"); // Only bits exist in n and l
WriteLine($"n | l      | {n | l,7} | {n | l:B8}"); // All bits exist in n or l
WriteLine($"n ^ l      | {n ^ l,7} | {n ^ l:B8}"); // Only bits exist in n or l

WriteLine();
WriteLine($"l * 8      | {l * 8,7} | {l * 8:B8}");
WriteLine($"l << 3     | {l << 3,7} | {l << 3:B8}"); // equal to l * 8 - from 00001010 to 01010000
WriteLine($"n >> 1     | {n >> 1,7} | {n >> 1:B8}");

#endregion

static bool DoStuff()
{
    WriteLine("I am doing some stuff.");
    return true;
}
