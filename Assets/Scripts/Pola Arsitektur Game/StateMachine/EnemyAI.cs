using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform[] waypoints;
    IState currentState;
    float chaseRange = 10f;
    float attackRange = 2f;
    float moveSpeed = 3f;

    public Transform Player => player;
    public Transform[] Waypoints => waypoints;
    public float MoveSpeed => moveSpeed;

    void Start()
    {
        ChangeState(new PatrolStatee(this));
    }

    void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    public bool IsPlayerInChaseRange()
    {
        return Vector3.Distance(transform.position, player.position) <= chaseRange;
    }

    public bool IsPlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, player.position) <= attackRange;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
