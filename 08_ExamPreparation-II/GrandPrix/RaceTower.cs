using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private Track track;
    private List<Driver> registeredDrivers;
    private Stack<Driver> failedDrivers;

    public RaceTower()
    {
        this.registeredDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();
    }

    public bool IsRaceOver => this.track.CurrentLap == this.track.LapsNumber;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var driverType = commandArgs[0];
            var driverName = commandArgs[1];
            var hp = int.Parse(commandArgs[2]);
            var fuelAmount = double.Parse(commandArgs[3]);

            var tyreArgs = commandArgs.Skip(4).ToArray();

            Tyre tyre = this.CreateTyre(tyreArgs);

            Car car = new Car(hp, fuelAmount, tyre);

            Driver driver = this.CreateDriver(driverType, driverName, car);

            this.registeredDrivers.Add(driver);
        }
        catch { }
    }

    private Driver CreateDriver(string driverType, string driverName, Car car)
    {
        Driver driver = null;

        if (driverType == "Aggressive")
        {
            return new AggressiveDriver(driverName, car);
        }
        else if (driverType == "Endurance")
        {
            return new EnduranceDriver(driverName, car);
        }

        throw new ArgumentException("Invalid driver type!");
    }

    private Tyre CreateTyre(string[] tyreArgs)
    {
        var tyreType = tyreArgs[0];
        var tyreHardness = double.Parse(tyreArgs[1]);

        if (tyreType == "Ultrasoft")
        {
            var grip = double.Parse(tyreArgs[2]);
            return new UltrasoftTyre(tyreHardness, grip);
        }
        else if (tyreType == "Hard")
        {
            return new HardTyre(tyreHardness);
        }

        throw new ArgumentException("Invalid tyre!");
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var boxReason = commandArgs[0];
        var driverName = commandArgs[1];

        Driver driver = this.registeredDrivers.FirstOrDefault(d => d.Name == driverName);

        if (boxReason == "Refuel")
        {
            var fuelAmount = double.Parse(commandArgs[2]);
            driver.Refuel(fuelAmount);
        }
        else if (boxReason == "ChangeTyres")
        {
            var arguments = commandArgs.Skip(2).ToArray();
            Tyre tyre = CreateTyre(arguments);
            driver.ChangeTyres(tyre);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder builder = new StringBuilder();

        var numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps > this.track.LapsNumber - this.track.CurrentLap)
        {
            try
            {
                throw new ArgumentException($"There is no time! On lap {this.track.CurrentLap}.");
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }

        for (int lap = 0; lap < numberOfLaps; lap++)
        {
            for (int index = 0; index < this.registeredDrivers.Count; index++)
            {
                Driver driver = registeredDrivers[index];

                try
                {
                    driver.CompleteLap(this.track.TrackLength);
                }
                catch (ArgumentException e)
                {
                    driver.Fail(e.Message);
                    this.failedDrivers.Push(driver);
                    this.registeredDrivers.RemoveAt(index);
                    index--;
                }
            }

            this.track.CurrentLap++;

            var orderedDrivers = registeredDrivers
                .OrderByDescending(d => d.TotalTime).ToList();

            for (int i = 0; i < orderedDrivers.Count - 1; i++)
            {
                Driver overtakingDriver = orderedDrivers[i];
                Driver targetDriver = orderedDrivers[i + 1];

                bool overtakeHeppened = this.TryOverTake(overtakingDriver, targetDriver);

                if (overtakeHeppened)
                {
                    i++;
                    builder.AppendLine(
                        $"{overtakingDriver.Name} has overtaken {targetDriver.Name} on lap {this.track.CurrentLap}.");
                }
                else
                {
                    if (!overtakingDriver.IsRacing)
                    {
                        this.failedDrivers.Push(overtakingDriver);
                        this.registeredDrivers.Remove(overtakingDriver);
                    }
                }
            }
        }

        if (this.IsRaceOver)
        {
            Driver winner = this.registeredDrivers.OrderBy(d => d.TotalTime).First();
            builder.AppendLine($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.");
        }

        string result = builder.ToString().TrimEnd();
        return result;
    }

    private bool TryOverTake(Driver overtakingDriver, Driver targetDriver)
    {
        double timeDiff = overtakingDriver.TotalTime - targetDriver.TotalTime;
        bool success = false;

        bool aggresiveDriver = overtakingDriver is AggressiveDriver && overtakingDriver.Car.Tyre is UltrasoftTyre;
        bool enduranceDriver = overtakingDriver is EnduranceDriver && overtakingDriver.Car.Tyre is HardTyre;
        bool crash = (aggresiveDriver && this.track.Weather == Weather.Foggy) ||
                     (enduranceDriver && this.track.Weather == Weather.Rainy);

        if ((aggresiveDriver || enduranceDriver) && timeDiff <= 3)
        {
            if (crash)
            {
                overtakingDriver.Fail("Crashed");
                return false;
            }

            overtakingDriver.TotalTime -= 3;
            targetDriver.TotalTime += 3;
            return true;
        }
        else if (timeDiff <= 2)
        {
            overtakingDriver.TotalTime -= 2;
            targetDriver.TotalTime += 2;
            return true;
        }

        return false;
    }

    public string GetLeaderboard()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Lap {this.track.CurrentLap}/{this.track.LapsNumber}");

        IEnumerable<Driver> leaderBoardDrivers = this.registeredDrivers.OrderBy(d => d.TotalTime)
            .Concat(this.failedDrivers);

        int position = 1;

        foreach (var driver in leaderBoardDrivers)
        {
            builder.AppendLine($"{position} {driver.ToString()}");
            position++;
        }

        string result = builder.ToString().TrimEnd();
        return result;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var weatherType = commandArgs[0];

        var validWeather = Enum.TryParse(typeof(Weather), weatherType, out object weatherTypeObj);

        if (!validWeather)
        {
            throw new ArgumentException("Invalid weather type!");
        }

        Weather weather = Enum.Parse<Weather>(weatherType);

        this.track.Weather = weather;
    }
}