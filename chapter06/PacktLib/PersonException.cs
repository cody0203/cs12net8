namespace Packt.Shared;

public class PersonException : Exception
{
    // Constructors are not inherited, so we must explicitly declare and explicitly call the base constructor
    // to make them available.
    public PersonException() : base() {}

    public PersonException(string message) : base(message) {}

    public PersonException(string message, Exception innerException) : base(message, innerException) {}
}