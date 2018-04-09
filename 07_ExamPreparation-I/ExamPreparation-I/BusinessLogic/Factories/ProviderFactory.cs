﻿using System;
using System.Collections.Generic;
using System.Text;

public class ProviderFactory
{
    public Provider CreateProvider(List<string> args)
    {
        var type = args[0];
        var id = args[1];
        var energyOutput = double.Parse(args[2]);

        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
            case "Pressure":
                return new PressureProvider(id, energyOutput);
                default:
                    throw new ArgumentException();
        }
    }
}