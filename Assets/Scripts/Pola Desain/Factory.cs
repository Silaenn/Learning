using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void Attack();
}

public class MeleeEnemy : Enemy
{
    public override void Attack()
    {
        Debug.Log("Melee Enemy attacks with a sword!");
    }
}

public class RangedEnemy : Enemy
{
    public override void Attack()
    {
        Debug.Log("Ranged Enemy shoots an arrow!");
    }
}
public class Factory : MonoBehaviour
{
    [SerializeField] GameObject meleeEnemyPrefab;
    [SerializeField] GameObject rangedEnemyPrefab;

    void Start()
    {
        CreateEnemy("Melee", new Vector3(0f, 5f, 0f));
    }

    public Enemy CreateEnemy(string enemyType, Vector3 position)
    {
        GameObject enemyObject = null;
        switch (enemyType)
        {
            case "Melee":
                enemyObject = Instantiate(meleeEnemyPrefab, position, Quaternion.identity);
                return enemyObject.GetComponent<MeleeEnemy>();
            case "Ranged":
                enemyObject = Instantiate(rangedEnemyPrefab, position, Quaternion.identity);
                return enemyObject.GetComponent<RangedEnemy>();
            default:
                Debug.LogError("Unknown enemy type: " + enemyType);
                return null;
        }
    }
}
