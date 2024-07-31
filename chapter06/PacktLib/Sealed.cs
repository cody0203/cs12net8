public sealed class PreventInheritance // no one can inherit from this class
{}

// public class TryToInheritSealedClass : PreventInheritance {} // 'TryToInheritSealedClass': cannot derive from sealed type 'PreventInheritance'

public class Singer
{
    public virtual void Sing() // virtual allows this method can be overridden
    {
        WriteLine("Singing...");
    }
}

public class LadyGaga : Singer
{
    public sealed override void Sing() // The sealed keyword prevents overriding the method in subclasses
    {
        WriteLine("Singing with style...");
    }
}

public class LadyGagaJr : LadyGaga
{
    // public override void Sing() {} // cannot override inherited member because is sealed
}