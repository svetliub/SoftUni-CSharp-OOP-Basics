using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public List<Mission> Missions { get; set; }

    public Commando(int id, string firstName, string lastName, double salary, string corpsType, List<Mission> missions) : base(id, firstName, lastName, salary, corpsType)
    {
        this.Missions = missions;
    }

    public void CompleteMission(string missionCodeName)
    {
        IMission mission = Missions.FirstOrDefault(m => m.MissionName == missionCodeName);

        if (mission != null)
        {
            mission.Complete();
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Corps: {this.CorpsType}");
        sb.AppendLine($"{nameof(this.Missions)}:");

        foreach (var item in Missions)
        {
            sb.AppendLine($"  {item.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }
}