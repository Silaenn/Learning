using UnityEngine;

public class PatrolState : EnemyState
{
    Vector3[] waypoints;
    int currentWaypointIndex;
    float moveSpeed;

    public PatrolState(EnemyAi ai, Vector3[] waypoints, float moveSpeed) : base(ai)
    {
        this.waypoints = waypoints;
        this.moveSpeed = moveSpeed;
    }

    public override void Enter()
    {
        Debug.Log("Entering Patrol State");
    }

    public override void Update()
    {
        if (waypoints.Length == 0)
        {
            enemyAi.ChangeState(enemyAi.idleState);
            return;
        }

        float distanceToPlayer = Vector3.Distance(enemyAi.transform.position, enemyAi.Player.position);

        if (distanceToPlayer <= enemyAi.DetectionRange)
        {
            enemyAi.ChangeState(enemyAi.chaseState);
            return;
        }

        if (Vector3.Distance(enemyAi.transform.position, waypoints[currentWaypointIndex]) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            enemyAi.ChangeState(enemyAi.idleState);
            return;
        }
          enemyAi.transform.position = Vector3.MoveTowards(enemyAi.transform.position, waypoints[currentWaypointIndex], moveSpeed * Time.deltaTime
        );
        

    }

    public override void Exit()
    {
        Debug.Log("Exiting Patrol State");
    }   
}
