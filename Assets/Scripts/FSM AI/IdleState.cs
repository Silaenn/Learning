using UnityEngine;

public class IdleState : EnemyState
{
    float idleDuration;
    float enterTime;

    public IdleState(EnemyAi ai, float idleDuration) : base(ai)
    {
        this.idleDuration = idleDuration;
    }

    public override void Enter()
    {
        Debug.Log("Entering Idle State");
        enterTime = Time.time;
    }

    public override void Update()
    {
        float distanceToPlayer = Vector3.Distance(enemyAi.transform.position, enemyAi.Player.position);

        if (distanceToPlayer <= enemyAi.DetectionRange)
        {
            enemyAi.ChangeState(enemyAi.chaseState);
            return;
        }

        if (Time.time - enterTime >= idleDuration)
        {
            enemyAi.ChangeState(enemyAi.patrolState);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Idle State");
    }
}
