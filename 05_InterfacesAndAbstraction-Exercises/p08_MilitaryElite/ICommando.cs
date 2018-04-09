using System;
using System.Collections.Generic;
using System.Text;

public interface ICommando
{
    List<Mission> Missions { get; set; }

    void CompleteMission(string missionCodeName);
}