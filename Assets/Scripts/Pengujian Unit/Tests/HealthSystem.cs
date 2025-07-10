using UnityEngine;

public class HealthSystem
{
    public int Health { get; set; }
    public bool isDead => Health <= 0;

    public HealthSystem(int initialHealth)
    {
        Health = initialHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0) return;
        Health = Mathf.Max(0, Health - damage);
    }
}
