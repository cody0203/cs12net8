#region Implicit and explicit interface implementations examples

// NewPerson p = new();

// p.Lose(); // Calls implicit implementation of losing a key

// ((IGamePlayer)p).Lose(); // Call explicit implementation of losing a game

// // Alternative way to do the same.
// IGamePlayer player = p as IGamePlayer;
// player.Lose(); // Call explicit implementation of losing a game

public interface IGamePlayer
{
    void Lose();
}

public interface IKeyHolder
{
    void Lose();
}

public class NewPerson : IKeyHolder, IGamePlayer
{
    public void Lose() // Implicit implementation
    {
        // Implement losing a key
    }

    void IGamePlayer.Lose() // Explicit implementation
    {
        // Implement losing a game
    }
}

#endregion