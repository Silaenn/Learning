using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string id;
    public string itemName;
    public Sprite icon;
    public int price;
    public ItemType itemType;
    public int maxStack;
    public string description;
}

public enum ItemType { Weapon, Armor, Consumable }