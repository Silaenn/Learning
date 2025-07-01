using System.Collections.Generic;
using BehaviorTree;

public class GuardBT : Tree
{
    public UnityEngine.Transform[] waypoints;
    public static float speed = 2f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;


    protected override Node SetUpTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequance(new List<Node>
            {
                new CheckEnemyAttackRange(transform),
                new TaskAttack(transform),
            }),
            new Sequance(new List<Node>
            {
                new CheckEnemyAiRange(transform),
                new TaskGoToTarget(transform),
            }),
            new TaskPatrol(transform, waypoints),
        });

        return root;
    }
}
