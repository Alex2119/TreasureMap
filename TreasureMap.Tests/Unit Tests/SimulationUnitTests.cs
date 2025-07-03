using TreasureMap.Entities;

namespace TreasureMap.Tests;

/// <summary>
/// Represents a set of tests for the simulation of an adventure game.
/// </summary>
public class SimulationUnitTests
{
    /// <summary>
    /// Tests if the adventurer collects treasure when moving forward onto a tile with treasure.
    /// </summary>
    [Fact]
    public void Adventurer_Collects_Treasure_When_Moving_Forward()
    {
        //Arrange
        var map = new Map(3, 3);
        map.Tiles[1, 0].Type = TileType.Treasure;
        map.Tiles[1, 0].TreasureCount = 1;

        var adventurer = new Adventurer
        {
            Name = "TestAdventurer",
            X = 1,
            Y = 1,
            Direction = Orientation.N,
            Movements = new Queue<Movement>(new[] { Movement.A })
        };

        map.Adventurers.Add(adventurer);
        var simulation = new Simulation(map);

        // Act
        simulation.Run();

        // Assert
        Assert.Equal(1, adventurer.CollectedTreasures);
        Assert.Equal(1, adventurer.X);
        Assert.Equal(0, adventurer.Y);
        Assert.Equal(0, map.Tiles[1,0].TreasureCount);
    }

    /// <summary>
    /// Tests if the adventurer turns left correctly when instructed to do so.
    /// </summary>
    [Fact]
    public void Adventurer_Turns_Left_Correctly()
    {
        // Arrange
        var map = new Map(3, 3);
        var adventurer = new Adventurer
        {
            Name = "Test",
            X = 1,
            Y = 1,
            Direction = Orientation.N,
            Movements = new Queue<Movement>([Movement.G])
        };
        map.Adventurers.Add(adventurer);

        var simulation = new Simulation(map);

        // Act
        simulation.Run();

        // Assert
        Assert.Equal(Orientation.W, adventurer.Direction);
        Assert.Equal(1, adventurer.X); // Pas de déplacement
        Assert.Equal(1, adventurer.Y);
    }

    /// <summary>
    /// Tests if the adventurer turns right correctly when instructed to do so.
    /// </summary>
    [Fact]
    public void Adventurer_Turns_Right_Correctly()
    {
        //Arrange
        var map = new Map(3, 3);
        var adventurer = new Adventurer
        {
            Name = "Test",
            X = 1,
            Y = 1,
            Direction = Orientation.N,
            Movements = new Queue<Movement>(new[] { Movement.D })
        };
        map.Adventurers.Add(adventurer);

        var simulation = new Simulation(map);

        //Act
        simulation.Run();

        //Assert
        Assert.Equal(Orientation.E, adventurer.Direction);
        Assert.Equal(1, adventurer.X);
        Assert.Equal(1, adventurer.Y);
    }

    /// <summary>
    /// Tests if the adventurer cannot move into a mountain tile.
    /// </summary>
    [Fact]
    public void Adventurer_Cannot_Move_Into_Mountain()
    {
        // Arrange
        var map = new Map(3, 3);

        // I put a mountain in (1, 0)
        map.Tiles[1, 0].Type = TileType.Mountain;

        var adventurer = new Adventurer
        {
            Name = "Test",
            X = 1,
            Y = 1,
            Direction = Orientation.N,
            Movements = new Queue<Movement>(new[] { Movement.A })
        };
        map.Adventurers.Add(adventurer);

        var simulation = new Simulation(map);

        // Act
        simulation.Run();

        // Assert
        Assert.Equal(1, adventurer.X);
        Assert.Equal(1, adventurer.Y);
    }

    /// <summary>
    /// Tests if the adventurer cannot leave the map bounds when trying to move outside of it.
    /// </summary>
    [Fact]
    public void Adventurer_Cannot_Leave_Map_Bounds()
    {
        // Arrange 
        var map = new Map(3, 3);

        var adventurer = new Adventurer
        {
            Name = "Test",
            X = 0,
            Y = 0,
            Direction = Orientation.N, // The adventurer will try to move north, which is out of bounds
            Movements = new Queue<Movement>(new[] { Movement.A })
        };
        map.Adventurers.Add(adventurer);

        var simulation = new Simulation(map);

        // Act 
        simulation.Run();

        // Assert the adventurer will not move out of bounds
        Assert.Equal(0, adventurer.X);
        Assert.Equal(0, adventurer.Y);
    }

    /// <summary>
    /// Tests if the adventurer cannot move into another adventurer's position.
    /// </summary>
    [Fact]
    public void Adventurer_Cannot_Move_Into_Other_Adventurer()
    {
        // Arrange
        var map = new Map(3, 3);

        var blockingAdventurer = new Adventurer
        {
            Name = "Blocker",
            X = 1,
            Y = 0,
            Direction = Orientation.S,
            Movements = new Queue<Movement>()
        };

        var adventurer = new Adventurer
        {
            Name = "Test",
            X = 1,
            Y = 1,
            Direction = Orientation.N,
            Movements = new Queue<Movement>(new[] { Movement.A })
        };

        map.Adventurers.Add(blockingAdventurer);
        map.Adventurers.Add(adventurer);

        var simulation = new Simulation(map);

        // Act
        simulation.Run();

        // Assert the second adventurer does not move into the first adventurer's position
        Assert.Equal(1, adventurer.X);
        Assert.Equal(1, adventurer.Y);
    }
    

}
