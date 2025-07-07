using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    int totalPoints = 0;
    void Start()
    {
        MissionSystem missionSystem = FindAnyObjectByType<MissionSystem>();

        if (missionSystem != null)
        {
            missionSystem.OnMissionCompleted += AddReward;
        }
    }

    void AddReward(string missionName, int reward)
    {
        totalPoints += reward;
        Debug.Log($"Total poin: {totalPoints}");
    }

    void OnDestroy()
    {
        MissionSystem missionSystem = FindAnyObjectByType<MissionSystem>();

        if (missionSystem != null)
        {
            missionSystem.OnMissionCompleted -= AddReward;
        }
    }
}
