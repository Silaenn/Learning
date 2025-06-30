using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3[] waypoints;
    [SerializeField] float patrolSpeed = 2f;
    [SerializeField] float chaseSpeed = 4f;
    [SerializeField] float detectionRange = 10f;
    [SerializeField] float attackRange = 2f;
    [SerializeField] float attackCooldown = 1f;
    [SerializeField] float timeIdle = 3f;

    public Transform Player => player;
    public float DetectionRange => detectionRange;
    public float AttackRange => attackRange;

    public EnemyState patrolState { get; set; }
    public EnemyState chaseState { get; set; }
    public EnemyState attackState { get; set; }
    public EnemyState idleState { get; set; }

    EnemyState currentState;

    void Awake()
    {
        patrolState = new PatrolState(this, waypoints, patrolSpeed);
        chaseState = new ChaseState(this, chaseSpeed, attackRange);
        attackState = new AttackState(this, attackCooldown);
        idleState = new IdleState(this, timeIdle);
    }

    void Start()
    {
        currentState = patrolState; 
        currentState.Enter();
    }

    void Update()
    {
        currentState.Update();
    }

    public void ChangeState(EnemyState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }


}
