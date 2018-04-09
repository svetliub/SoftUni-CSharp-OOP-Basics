using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public List<IRepair> Repairs { get; set; }

    public Engineer(int id, string firstName, string lastName, double salary, string corpsType, List<IRepair> repairs) : base(id, firstName, lastName, salary, corpsType)
    {
        this.Repairs = repairs;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Corps: {this.CorpsType}");
        sb.AppendLine($"{nameof(this.Repairs)}:");

        foreach (var item in Repairs)
        {
            sb.AppendLine($"  {item.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }
}