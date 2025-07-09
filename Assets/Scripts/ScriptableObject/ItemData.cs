using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Game/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int damage;
    public float attackSpeed;
    public int price;
}