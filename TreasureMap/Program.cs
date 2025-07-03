using TreasureMap;

class Program
{
    static void Main(string[] args)
    {
        try
        {
           Console.WriteLine("Welcome to the Treasure Map Simulation!");

            var map = Parser.Load("input.txt");

            var simulation = new Simulation(map);
            simulation.Run();

            Writer.Save(map, "result.txt");
            Console.WriteLine("Simulation completed. Results saved to result.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}