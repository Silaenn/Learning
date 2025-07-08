using UnityEngine;

public class AudioManagerEvent : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinClip;
    [SerializeField] AudioClip damageClip;

    void OnEnable()
    {
        GameEventBus.OnCoinColledted += PlayCoinSound;
        GameEventBus.OnPlayerDamaged += PlayDamageSound;
    }

    void OnDisable()
    {
        GameEventBus.OnCoinColledted -= PlayCoinSound;
        GameEventBus.OnPlayerDamaged -= PlayDamageSound;
    }

    void PlayCoinSound(int score)
    {
        audioSource.PlayOneShot(coinClip);
    }

    void PlayDamageSound(int damage)
    {
        audioSource.PlayOneShot(damageClip);
    }
}
