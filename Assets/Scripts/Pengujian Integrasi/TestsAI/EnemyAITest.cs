using NUnit.Framework;

public class EnemyAITest
{
    [Test]
    public void TestEnemyTakesDamage()
    {
        var enemyHealth = new EnemyHealth();
        enemyHealth.SetHealth(100);

        var playerAttack = new PlayerAttack();
        playerAttack.Attack(enemyHealth, 20);

        Assert.AreEqual(80, enemyHealth.GetHealth(), "HP musuh harus berkurang menjadi 80");
    }
}
