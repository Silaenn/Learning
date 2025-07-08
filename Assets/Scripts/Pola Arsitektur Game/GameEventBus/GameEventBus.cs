using UnityEngine;

public class GameEventBus : MonoBehaviour
{
    public delegate void CoinCollectedEventHandler(int score);
    public static event CoinCollectedEventHandler OnCoinColledted;

    public delegate void PlayerDamageEventHandler(int damage);
    public static event PlayerDamageEventHandler OnPlayerDamaged;

    public static void PublishCoinColledcted(int score)
    {
        OnCoinColledted?.Invoke(score);
    }

    public static void PublishPlayerDamaged(int damage)
    {
        OnPlayerDamaged?.Invoke(damage);
    }
}
