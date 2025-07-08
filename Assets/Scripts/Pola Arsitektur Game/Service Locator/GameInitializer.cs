using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] AudioService audioService;
    [SerializeField] AudioClip coinClip;
    [SerializeField] AudioClip damageClip;

    void Awake()
    {
        ServiceLocator.RegisterService<IAudioService>(audioService);
    }

    public AudioClip GetCoinClip() => coinClip;
    public AudioClip GetDamageClip() => damageClip;
}
