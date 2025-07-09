using UnityEngine;

public class PlayerHealthSO : MonoBehaviour
{
    public GameEvent playerDamagedEvent;
    [SerializeField] private int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Player HP: {health}");
        if (playerDamagedEvent != null)
        {
            playerDamagedEvent.Raise(); // Memicu event
        }
    }
}
