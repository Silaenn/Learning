using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public ItemData weapon;

    void Start()
    {
        Debug.Log($"Using {weapon.itemName} with {weapon.damage} damage!");
    }
}