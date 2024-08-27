using Packt.Shared;

partial class Program
{
    // Convention for methods names that handle events is ObjectName_EventName
    private static void Cody_Shout(object? sender, EventArgs e)
    {
        if (sender is null) return;

        if (sender is not Person p) return;

        WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
    }

    private static void Cody_Shout_2(object? sender, EventArgs e)
    {
        WriteLine("Stop it!");
    }
}