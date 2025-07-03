namespace TreasureMap.Entities;

/// <summary>
/// Represents an adventurer in the adventure game.
/// </summary>
public class Adventurer
{
    public string Name { get; set; } = string.Empty;
    public int X { get; set; }
    public int Y { get; set; }
    public Orientation Direction { get; set; }
    public Queue<Movement> Movements { get; set; } = new ();
    public int CollectedTreasures { get; set; } = 0;
}

/// <summary>
/// Represents the orientation of an adventurer.
/// N for North, E for East, S for South, and W for West.
/// </summary>
public enum Orientation
{
    N,
    E,
    S,
    W,
}

/// <summary>
/// Represents the possible movements of an adventurer.
/// A for Advance, G for Turn Left, and D for Turn Right. (FR =  A is for "Avancer", G for "Gauche", and D for "Droite")
/// </summary>
public enum Movement
{
    A,
    G,
    D,
}
