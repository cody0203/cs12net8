namespace Packt.Shared;

public interface INoImplementation
{
    void Alpha();
}

public interface ISomeImplementation
{
    void Alpha();  // Must be implemented
    void Beta()
    {

    }
}

public abstract class PartiallyImplemented
{
    public abstract void Gamma(); // Must be implemented

    public virtual void Delta()
    {

    }
}

public class FullyImplemented : PartiallyImplemented, ISomeImplementation
{
    public void Alpha()
    {

    }

    public override void Gamma()
    {
        
    }
}