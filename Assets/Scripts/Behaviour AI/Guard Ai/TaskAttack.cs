using UnityEngine;

using BehaviorTree;
public class TaskAttack : Node
{
    Transform _lastTarget;
    EnemyManager _enemyManager;
    float _attackTime = 1f;
    float _attackCounter = 0f;
    public TaskAttack(Transform transform)
    {

    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target != _lastTarget)
        {
            _enemyManager = target.GetComponent<EnemyManager>();
            _lastTarget = target;
        }

        _attackCounter += Time.deltaTime;
        if (_attackCounter >= _attackTime)
        {
            bool enemyIsDead = _enemyManager.TakeHit();
            if (enemyIsDead)
            {
                ClearData("target");
            }
            else
            {
               _attackCounter = 0f;
            }

        }

        state = NodeState.RUNNING;
        return state;
    }
}
