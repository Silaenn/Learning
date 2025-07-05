using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int poolSize = 20;
    List<GameObject> bullets = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }

        return null;
    }
}
