namespace Packt.Shared;

public class ImmutablePerson
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}

public record ImmutableVehicle
{
    public int Wheels { get; init; }
    public string? Color { get; init; }
    public string? Brand { get; init; }
}

// public record ImmutableAnimal
// {
//     public string? Name { get; init; }
//     public string? Species { get; init; }

//     public ImmutableAnimal(string Name, string Species)
//     {
//         this.Name = Name;
//         this.Species = Species;
//     }

//     public void Deconstruct(out string? name, out string? species)
//     {
//         name = Name;
//         species = Species;
//     }
// }

// Shorthand of the above declaration which can be generated
public record ImmutableAnimal(string Name, string Species);
