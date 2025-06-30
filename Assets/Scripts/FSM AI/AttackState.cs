using UnityEngine;

public class AttackState : EnemyState
{
    float attackCooldown;
    float lastAttackTime;

    public AttackState(EnemyAi ai, float attackCooldown) : base(ai)
    {
        this.attackCooldown = attackCooldown;
    }

    public override void Enter()
    {
        Debug.Log("Entering Attack State");
        lastAttackTime = 0f;
    }

    public override void Update()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            Debug.Log("Attacking Player!");
        }

        float distanceToPlayer = Vector3.Distance(enemyAi.transform.position, enemyAi.Player.position);

        if (distanceToPlayer > enemyAi.AttackRange)
        {
            enemyAi.ChangeState(enemyAi.chaseState);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Attack State");
    }
}
