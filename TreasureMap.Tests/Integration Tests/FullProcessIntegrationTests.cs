namespace TreasureMap.Tests.Integration_Tests;

/// <summary>
/// Represents a set of integration tests for the full process of loading, simulating, and saving an adventure map.
/// </summary>
public class FullProcessIntegrationTests
{
    /// <summary>
    /// Tests the full process of loading a map, running a simulation, and saving the result to a file.
    /// </summary>
    [Fact]
    public void Full_Process_With_File_IO_Produces_Expected_Result()
    {
        // Arrange
        string inputPath = "test_input.txt";
        string outputPath = "test_output.txt";

        File.WriteAllLines(inputPath, new[]
        {
        "C - 2 - 2",
        "T - 0 - 1 - 1",
        "A - Lara - 0 - 0 - S - A"
        });

        // Act
        var map = Parser.Load(inputPath);
        var simulation = new Simulation(map);
        simulation.Run();
        Writer.Save(map, outputPath);

        // Assert
        var lines = File.ReadAllLines(outputPath);

        // Lara the adventurer pick a treasure in (0,1)
        Assert.Contains("A - Lara - 0 - 1 - S - 1", lines); 

        // Cleanup
        File.Delete(inputPath);
        File.Delete(outputPath);
    }

}
