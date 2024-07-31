namespace Packt.Shared;

public class Employee : Person
{
    public string? EmployeeCode { get; set; }
    public DateOnly HireDate { get; set; }

    #region Hiding Members
    public new void WriteToConsole()
    {
        WriteLine($"{Name} was born on {Born:dd/MM/yy} and hired on {HireDate:dd/MM/yy}");
    }
    #endregion
}