using UnityEngine;

public class PatrolStatee : IState
{
    EnemyAI enemy;
    int currentWaypointIndex;

    public PatrolStatee(EnemyAI enemy) => this.enemy = enemy;

    public void Enter()
    {
        Debug.Log("Musuh mulai patrol");
    }

    public void Update()
    {
        if (enemy.IsPlayerInChaseRange())
        {
            enemy.ChangeState(new ChaseStatee(enemy));
            return;
        }

        Transform targetWaypoint = enemy.Waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - enemy.transform.position).normalized;
        enemy.transform.position += direction * enemy.MoveSpeed * Time.deltaTime;

        if (Vector3.Distance(enemy.transform.position, targetWaypoint.position) < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % enemy.Waypoints.Length;
        }
    }

    public void Exit()
    {
        Debug.Log("Musuh berhenti patrol");
    }
}
