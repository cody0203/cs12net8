using System.Diagnostics.CodeAnalysis;

partial class Program
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    private const string DigitsOnlyText = @"^\d+$";

    [StringSyntax(StringSyntaxAttribute.Regex)]
    private const string CommaSeparatorText = "(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)";
}