using TreasureMap.Entities;

namespace TreasureMap;

/// <summary>
/// Provides methods to load and parse an adventure map file (.txt file).
/// </summary>
public static class Parser
{
    /// <summary>
    /// Loads a map from a specified file path.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Map Load(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        Map? map = null;
        foreach (var line in lines)
        {
            if(string.IsNullOrWhiteSpace(line) || line.StartsWith('#')) continue;

            var parts = line.Split(" - ");

            switch (parts[0])
            {
                case "C":
                    map = new Map(int.Parse(parts[1]),
                        int.Parse(parts[2])
                    );
                    break;
                case "M":
                    {
                        EnsureMapInitialized(map);
                        int x = int.Parse(parts[1]);
                        int y = int.Parse(parts[2]);
                        if (map is not null)
                            map.Tiles[x,y].Type = TileType.Mountain;
                        break;
                    }
                case "T":
                    {
                        EnsureMapInitialized(map);
                        int x = int.Parse(parts[1]);
                        int y = int.Parse(parts[2]);
                        int treasureCount = int.Parse(parts[3]);
                        map!.Tiles[x, y].Type = TileType.Treasure;
                        map.Tiles[x, y].TreasureCount = treasureCount;
                        break;
                    }
                case "A":
                    EnsureMapInitialized(map);
                    var adventurer = new Adventurer
                    {
                        Name = parts[1],
                        X = int.Parse(parts[2]),
                        Y = int.Parse(parts[3]),
                        Direction = Enum.Parse<Orientation>(parts[4]),
                        Movements = new Queue<Movement>(parts[5].Select(c => Enum.Parse<Movement>(c.ToString())))
                    };
                    if(map is not null)
                       map.Adventurers.Add(adventurer);
                    break;
            }
        }
        if(map is null)
            throw new InvalidOperationException("No valid file.");

        return map;
    }

    /// <summary>
    /// Ensures that the map is initialized before adding elements to it.
    /// </summary>
    /// <param name="map"></param>
    /// <exception cref="InvalidOperationException"></exception>
    private static void EnsureMapInitialized(Map? map)
    {
        if (map is null)
            throw new InvalidOperationException("The map must be defined before adding elements.");
    }
}
