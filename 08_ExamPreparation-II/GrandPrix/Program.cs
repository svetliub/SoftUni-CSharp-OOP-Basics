using System;

class Program
{
    static void Main(string[] args)
    {
        int numberOfLaps = int.Parse(Console.ReadLine());
        int truckLength = int.Parse(Console.ReadLine());

        RaceTower raceTower = new RaceTower();
        raceTower.SetTrackInfo(numberOfLaps, truckLength);

        Engine engine = new Engine(raceTower);
        engine.Run();
    }
}