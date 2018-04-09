using System;
using System.Collections.Generic;
using System.Text;

public class Ferrari : ICar
{
    public string Model { get; set; }

    public string DriverName { get; set; }

    public Ferrari(string driverName)
    {
        this.Model = "488-Spider";
        this.DriverName = driverName;
    }

    public string PushGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{UseBrakes()}/{PushGasPedal()}/{this.DriverName}";
    }
}
