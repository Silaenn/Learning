using UnityEngine;

public class ChaseState : EnemyState
{
    float moveSpeed;
    float attackRange;

    public ChaseState(EnemyAi ai, float moveSpeed, float attackRange) : base(ai)
    {
        this.moveSpeed = moveSpeed;
        this.attackRange = attackRange;
    }

    public override void Enter()
    {
        Debug.Log("Entering Chase State");
    }

    public override void Update()
    {
        enemyAi.transform.position = Vector3.MoveTowards(enemyAi.transform.position, enemyAi.Player.position, moveSpeed * Time.deltaTime);

        float distanceToPlayer = Vector3.Distance(enemyAi.transform.position, enemyAi.Player.position);

        if (distanceToPlayer <= attackRange)
        {
            enemyAi.ChangeState(enemyAi.attackState);
        }
        else if (distanceToPlayer > enemyAi.DetectionRange)
        {
            enemyAi.ChangeState(enemyAi.patrolState);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Chase State");
    }
}
