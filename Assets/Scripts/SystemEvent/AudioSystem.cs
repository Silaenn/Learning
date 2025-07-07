using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] AudioSource missionCompleteSound;

    void Start()
    {
        MissionSystem missionSystem = FindAnyObjectByType<MissionSystem>();

        if (missionSystem != null)
        {
            missionSystem.OnMissionCompleted += PlayMissionSound;
        }
    }

    void PlayMissionSound(string missionName, int reward)
    {
        missionCompleteSound.Play();
    }

    void OnDestroy()
    {
        MissionSystem missionSystem = FindAnyObjectByType<MissionSystem>();

        if (missionSystem != null)
        {
            missionSystem.OnMissionCompleted -= PlayMissionSound;
        }
    }
}
