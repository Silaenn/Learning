using TMPro;
using UnityEngine;

public class MissionUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI missionText;

    void Start()
    {
        MissionSystem missionSystem = FindAnyObjectByType<MissionSystem>();
        if (missionSystem != null)
        {
            missionSystem.OnMissionCompleted += UpdateMissionUI;
        }
    }

    void UpdateMissionUI(string missionName, int reward)
    {
        missionText.text = $"Misi Selesai: {missionName}\nHadiah: {reward} poin";
    }

    void OnDestroy()
    {
        MissionSystem missionSystem = FindAnyObjectByType<MissionSystem>();

        if (missionSystem != null)
        {
            missionSystem.OnMissionCompleted -= UpdateMissionUI;
        }
    }

    
}
