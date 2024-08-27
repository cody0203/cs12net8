namespace Packt.Shared;

// Good practice:
// If total memory used by all the fields in type is 16 bytes or less, or only uses value types, or don't want inherit from it -> use struct
// Otherwise, use class.
public struct DisplacementVector
{
    public int X { get; set; }
    public int Y { get; set; }

    public DisplacementVector(int initialX, int initialY)
    {
        X = initialX;
        Y = initialY;
    }

    public static DisplacementVector operator +(
        DisplacementVector vector1,
        DisplacementVector vector2
    )
    {
        return new (
            vector1.X + vector2.X,
            vector1.Y + vector2.Y
            );
    }
}