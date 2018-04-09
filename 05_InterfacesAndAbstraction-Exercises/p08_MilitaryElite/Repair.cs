using System;
using System.Collections.Generic;
using System.Text;

public class Repair : IRepair
{
    public string PartName { get; set; }

    public int WorkHours { get; set; }

    public Repair(string partName, int workHours)
    {
        this.PartName = partName;
        this.WorkHours = workHours;
    }

    public override string ToString()
    {
        return $"Part Name: {this.PartName} Hours Worked: {this.WorkHours}";
    }
}