using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public List<ISoldier> Privates { get; set; }

    public LeutenantGeneral(int id, string firstName, string lastName, double salary, List<ISoldier> privates) : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"{nameof(this.Privates)}:");

        foreach (var item in Privates)
        {
            sb.AppendLine($"  {item.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }
}