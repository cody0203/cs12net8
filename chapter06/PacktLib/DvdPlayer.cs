namespace Packt.Shared;

#region Default Implementations
public class DvdPlayer : IPlayble
{
    public void Pause()
    {
        WriteLine("Dvd Player is pausing!");
    }

    public void Play()
    {
        WriteLine("Dvd player is playing");
    }
}
#endregion