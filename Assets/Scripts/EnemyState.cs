using UnityEngine;

public abstract class EnemyState
{
    protected EnemyAi enemyAi;
    public EnemyState(EnemyAi ai) => enemyAi = ai;
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
