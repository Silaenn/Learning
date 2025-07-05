using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int damage = 10;
    public float fireRate = 0.5f;
    public int maxAmmo = 30;
    public GameObject projectilePrefab;
}
