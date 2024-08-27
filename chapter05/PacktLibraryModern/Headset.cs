namespace Packt.Shared;

public class Headset(string manualfacturer, string productName)
{
    public string Manualfacturer { get; set; } = manualfacturer;
    public string ProductName { get; set; } = productName;

    // Default parameterless constructor calls the primary constructor
    public Headset() : this("Microsoft", "Hololens") {}
    
}