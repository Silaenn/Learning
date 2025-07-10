using UnityEngine;

public class EnemyHealth
{
    int health;
    public void SetHealth(int value) => health = value;
    public int GetHealth() => health;
    public void TakeDamage(int damage) => health -= damage;
}
