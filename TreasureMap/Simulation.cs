using TreasureMap.Entities;

namespace TreasureMap;

/// <summary>
/// Represents the simulation of an adventure game.
/// </summary>
public class Simulation
{
    private Map _map;

    /// <summary>
    /// Initializes a new instance of the <see cref="Simulation"/> class with the specified map.
    /// </summary>
    /// <param name="map"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public Simulation(Map map)
    {
        _map = map ?? throw new ArgumentNullException(nameof(map), "Map cannot be null");
    }
    public void Run()
    {
        bool stillMoving = true;
        while (stillMoving)
        {
            stillMoving = false;
            foreach (var adventurer in _map.Adventurers)
            {
                if (adventurer.Movements.Count > 0)
                {
                    stillMoving = true;
                    ExecuteMove(adventurer, adventurer.Movements.Dequeue());
                }
            }
        }
    }

    /// <summary>
    /// Executes a movement for the specified adventurer based on the given move command.
    /// </summary>
    /// <param name="adventurer"></param>
    /// <param name="move"></param>
    private void ExecuteMove(Adventurer adventurer, Movement move)
    {
        // G: tourner à gauche, D: tourner à droite, A: avancer
        switch (move)
        {
            case Movement.G:
                adventurer.Direction = adventurer.Direction switch
                {
                    Orientation.N => Orientation.W,
                    Orientation.W => Orientation.S,
                    Orientation.S => Orientation.E,
                    Orientation.E => Orientation.N,
                    _ => adventurer.Direction
                };
                break;
            case Movement.D:
                adventurer.Direction = adventurer.Direction switch
                {
                    Orientation.N => Orientation.E,
                    Orientation.E => Orientation.S,
                    Orientation.S => Orientation.W,
                    Orientation.W => Orientation.N,
                    _ => adventurer.Direction
                };
                break;
            case Movement.A:
                int newX = adventurer.X, newY = adventurer.Y;
                switch (adventurer.Direction)
                {
                    case Orientation.N: newY -= 1; break;
                    case Orientation.S: newY += 1; break;
                    case Orientation.E: newX += 1; break;
                    case Orientation.W: newX -= 1; break;
                }
                // Vérifier les limites de la carte
                if (newX >= 0 && newX < _map.Width && newY >= 0 && newY < _map.Height)
                {
                    var tile = _map.Tiles[newX, newY];
                    // Vérifier que la case n'est pas une montagne et qu'aucun autre aventurier n'est dessus
                    bool occupied = _map.Adventurers.Any(a => a != adventurer && a.X == newX && a.Y == newY);
                    if (tile.Type != TileType.Mountain && !occupied)
                    {
                        adventurer.X = newX;
                        adventurer.Y = newY;
                        // Ramasser un trésor si présent
                        if (tile.Type == TileType.Treasure && tile.TreasureCount > 0)
                        {
                            adventurer.CollectedTreasures++;
                            tile.TreasureCount--;
                        }
                    }
                }
                break;
        }
    }
}
