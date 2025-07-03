namespace TreasureMap.Entities;

/// <summary>
/// Represents a map for the adventure game.
/// </summary>
public class Map
{
    public int Width { get; set; }
    public int Height { get; set; }
    public Tile[,] Tiles { get; set; }

    public List<Adventurer> Adventurers { get; set; } = new ();

    /// <summary>
    /// Initializes a new instance of the <see cref="Map"/> class with specified width and height.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public Map(int width, int height)
    {
        Width = width;
        Height = height;
        Tiles = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tiles[x, y] = new Tile(x, y);
            }
        }
    }
}
