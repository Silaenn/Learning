using UnityEngine;

public class ChaseStatee : IState
{
    EnemyAI enemy;
    public ChaseStatee(EnemyAI enemy) => this.enemy = enemy;
    public void Enter()
    {
        Debug.Log("Musuh mulai mengejar");
    }

    public void Update()
    {
        if (enemy.IsPlayerInAttackRange())
        {
            enemy.ChangeState(new AttackStatee(enemy));
            return;
        }
        if (!enemy.IsPlayerInChaseRange())
        {
            enemy.ChangeState(new PatrolStatee(enemy));
            return;
        }

        Vector3 direction = (enemy.Player.position - enemy.transform.position).normalized;
        enemy.transform.position += direction * enemy.MoveSpeed * Time.deltaTime;
    }

    public void Exit()
    {
        Debug.Log("Musuh berhenti mengejar");
    }
}
