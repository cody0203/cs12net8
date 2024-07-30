namespace Packt.Shared;

#region Default Implementations
public interface IPlayble {
    void Play();
    void Pause();
    void Stop()
    {
        WriteLine("Default implementation of Stop");
    }
}
#endregion