using static System.Console;

partial class Program {
    // Always separate functions that will be executed in Program class to another file
    // and inside the partial Program class block.
    // So they will be merged into the automatically generated Program class
    // at the same level with <Main>$ method instead of as local functions inside <Main>$ method
    static void WhatsMyNamespace()
    {
        WriteLine($"Namespace of Program class: {typeof(Program).Namespace ?? "null"}");
    }
}
