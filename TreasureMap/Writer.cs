using TreasureMap.Entities;

namespace TreasureMap;

/// <summary>
/// Provides methods to write an adventure map to a file.
/// </summary>
public static class Writer
{
    /// <summary>
    /// Saves the specified map to a file in the adventure game format.
    /// </summary>
    /// <param name="map"></param>
    /// <param name="filePath"></param>
    public static void Save(Map map, string filePath)
    {
        List<string> lines = new();

        lines.Add($"C - {map.Width} - {map.Height}");

        for (int x = 0; x < map.Width; x++)
        {
            for (int y = 0; y < map.Height; y++)
            {
                var tile = map.Tiles[x, y];
                if (tile.Type == TileType.Mountain)
                {
                    lines.Add($"M - {x} - {y}");
                }
                else if (tile.Type == TileType.Treasure && tile.TreasureCount > 0)
                {
                    lines.Add($"T - {x} - {y} - {tile.TreasureCount}");
                }
            }
        }

        foreach(var adventurer in map.Adventurers)
        {
            lines.Add($"A - {adventurer.Name} - {adventurer.X} - {adventurer.Y} - {adventurer.Direction} - {adventurer.CollectedTreasures}");
        }

        File.WriteAllLines(filePath, lines);
    }
}
