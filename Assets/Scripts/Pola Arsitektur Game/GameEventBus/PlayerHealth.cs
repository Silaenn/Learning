using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int health = 100;
    int score = 0;

    public void AddScore(int value)
    {
        score += value;
        GameEventBus.PublishCoinColledcted(value);
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Max(0, health - damage);
        GameEventBus.PublishPlayerDamaged(damage);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddScore(10);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) AddScore(10);
        if (Input.GetKeyDown(KeyCode.H)) TakeDamage(20);
    }
}
