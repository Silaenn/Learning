using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    HealthSystem healthSystem;

    [SetUp]
    public void SetUp()
    {
        healthSystem = new HealthSystem(100);
    }

    [Test]
    public void TakeDamage_ReducesHealthCorrectly()
    {
        healthSystem.TakeDamage(20);
        Assert.AreEqual(80, healthSystem.Health);
    }

    [Test]
    public void TakeDamage_HealthCannotGoBelowZero()
    {
        healthSystem.TakeDamage(150);
        Assert.AreEqual(0, healthSystem.Health);
    }

    [Test]
    public void TakeDamage_WhenHealthZero_SetsIsDead()
    {
        healthSystem.TakeDamage(100);
        Assert.IsTrue(healthSystem.isDead);
    }

    
    [Test]
    public void TakeDamage_NegativeDamage_DoesNotChangeHealth()
    {
        healthSystem.TakeDamage(-10);
        Assert.AreEqual(100, healthSystem.Health);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
