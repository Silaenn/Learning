using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] Transform firePoint;
    [SerializeField] BulletPool bulletPool;
    int currentAmmo;
    float nextFireTime;
    bool isReloading;

    void Start()
    {
        currentAmmo = weaponData.maxAmmo;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime && !isReloading && currentAmmo > 0)
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentAmmo < weaponData.maxAmmo)
        {
            StartCoroutine(Reload());
        }
    }

    void Fire()
    {
        GameObject bullet = bulletPool.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.GetComponent<Bullet>().damage = weaponData.damage;
            bullet.SetActive(true);
            currentAmmo--;
            nextFireTime = Time.time + weaponData.fireRate;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(2f);
        currentAmmo = weaponData.maxAmmo;
        isReloading = false;
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }
}
