using System;
using System.Collections.Generic;
using System.Text;

public interface ICar
{
    string Model { get; set; }

    string DriverName { get; set; }

    string UseBrakes();

    string PushGasPedal();
}