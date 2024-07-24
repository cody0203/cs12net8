namespace Packt.Shared;

public class Passenger
{
    public string? Name { get; set; }
}

public class BusinessClassPassenger : Passenger
{
    public override string ToString()
    {
        return $"Business Class: {Name}";
    }
}

public class FirstClassPassenger : Passenger
{
    public int AirMiles { get; set; }
    public override string ToString()
    {
        return $"First class with {AirMiles:N0} air miles: {Name}";
    }
}

public class CoachClassPassenger : Passenger
{
    public double CarryOnKg { get; set; }
    public override string ToString()
    {
        return $"Coach Class with {CarryOnKg:N0} KG carry on: {Name}";
    }
}