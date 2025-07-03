namespace TreasureMap.Entities;

/// <summary>
/// Represents a tile in the adventure map.
/// </summary>
public class Tile
{
    public int X { get; set; }
    public int Y { get; set; }
    public TileType Type { get; set; } = TileType.Plain;
    public int TreasureCount { get; set; } = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="Tile"/> class with specified coordinates.
    /// </summary>
    /// <param name="x">horizontal axis</param>
    /// <param name="y">vertical axis</param>
    public Tile(int x, int y)
    {
        X = x;
        Y = y;
    }

}

/// <summary>
/// Represents the type of a tile in the adventure map.
/// </summary>
public enum TileType
{
    Plain,
    Mountain,
    Treasure,
}
