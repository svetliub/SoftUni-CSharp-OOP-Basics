using System;
using System.Collections.Generic;
using System.Text;

public class Spy : Soldier, ISpy
{
    public int SpyCodeNumber { get; set; }

    public Spy(int id, string firstName, string lastName, int spyCodeNumber) : base(id, firstName, lastName)
    {
        this.SpyCodeNumber = spyCodeNumber;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Code Number: {this.SpyCodeNumber}");

        return sb.ToString().TrimEnd();
    }
}