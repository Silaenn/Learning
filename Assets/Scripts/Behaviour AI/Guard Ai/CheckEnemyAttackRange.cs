using UnityEngine;

using BehaviorTree;
public class CheckEnemyAttackRange : Node
{
    static int _enemyLayerMask = 1 << 6;

    Transform _transform;

    public CheckEnemyAttackRange(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");

        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;
        if (Vector3.Distance(_transform.position, target.position) <= GuardBT.attackRange)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
        
    }
}
