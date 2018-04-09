using System;
using System.Collections.Generic;
using System.Text;

public class Mission : IMission
{
    public string MissionName { get; set; }

    public MissionStateEnum MissionState { get; set; }

    public Mission(string missionName, string missionState)
    {
        this.MissionName = missionName;
        ValidateMissionState(missionState);
    }

    private void ValidateMissionState(string missionState)
    {
        if (!Enum.IsDefined(typeof(MissionStateEnum), missionState))
        {
            throw new ArgumentException();
        }
        this.MissionState = Enum.Parse<MissionStateEnum>(missionState);
    }

    public void Complete()
    {
        if (this.MissionState == MissionStateEnum.Finished)
        {
            throw new InvalidOperationException("Mission already finished!");
        }

        this.MissionState = MissionStateEnum.Finished;
    }

    public override string ToString()
    {
        return $"Code Name: {this.MissionName} State: {this.MissionState}";
    }
}