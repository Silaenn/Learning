using UnityEngine;

public class AttackStatee : IState
{
    EnemyAI enemy;
    float attackCooldown;
    float lastAttackTime;

    public AttackStatee(EnemyAI enemy) => this.enemy = enemy;

    public void Enter()
    {
        Debug.Log("Musuh mulai menyerang");
        attackCooldown = 1f;
    }

    public void Update()
    {
        if (!enemy.IsPlayerInAttackRange())
        {
            enemy.ChangeState(new ChaseStatee(enemy));
            return;
        }

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Debug.Log("Musuh menyerang pemain!");
            lastAttackTime = Time.time;
        }
    }

    public void Exit()
    {
        Debug.Log("Musuh berhenti menyerang");
    }
}
