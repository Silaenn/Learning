using UnityEngine;

public class PlayerAttack
{
    public void Attack(EnemyHealth target, int damage)
    {
        target.TakeDamage(damage);
    }
   
}
