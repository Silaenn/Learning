using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    public delegate void MissionComplateHandler(string missionName, int reward);
    public event MissionComplateHandler OnMissionCompleted;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            CompleteMission("Rescue Village", 100);
        }
    }

    void CompleteMission(string missionName, int reward)
    {
        Debug.Log($"Misi {missionName} selesai!");
        OnMissionCompleted?.Invoke(missionName, reward);
    }
}
