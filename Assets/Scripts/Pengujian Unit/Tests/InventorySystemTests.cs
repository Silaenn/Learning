using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class InventorySystemTests
{
    InventorySystem inventory;

    [SetUp]
    public void SetUp()
    {
        inventory = new InventorySystem(2);
    }

    [Test]
    public void AddItemWhenNotFull_AddsSuccessfully()
    {
        bool result = inventory.AddItem("Sword");
        Assert.IsTrue(result);
        Assert.IsTrue(inventory.HasItem("Sword"));
    }

    [Test]
    public void AddItem_WhenFull_ReturnFalse()
    {
        inventory.AddItem("Sowrd");
        inventory.AddItem("Shield");
        bool result = inventory.AddItem("Potion");
        Assert.IsFalse(result);
        Assert.IsFalse(inventory.HasItem("Potion"));
    }
}
