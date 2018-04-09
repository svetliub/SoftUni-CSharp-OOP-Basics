public interface IMission
{
    string MissionName { get; set; }

    MissionStateEnum MissionState { get; set; }

    void Complete();
}