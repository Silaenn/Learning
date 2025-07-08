using UnityEngine;

public class AudioService : MonoBehaviour, IAudioService
{
    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
            Debug.Log($"Playing sound: {clip.name}");
        }
    }
}
