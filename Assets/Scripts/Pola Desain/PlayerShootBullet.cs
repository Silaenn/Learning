using UnityEngine;

public class PlayerShootBullet : MonoBehaviour
{
   [SerializeField] private ObjectPooling bulletPool; // Referensi ke ObjectPool
    [SerializeField] private Transform firePoint;   // Posisi tembak (misalnya, ujung senjata)

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Tembak saat tekan spasi
        {
            GameObject bullet = bulletPool.GetBullet(); // Ambil peluru dari pool
            if (bullet != null)
            {
                bullet.transform.position = firePoint.position; // Atur posisi peluru
                bullet.transform.rotation = firePoint.rotation; // Atur rotasi peluru
                bullet.GetComponent<BulletPooll>().SetPool(bulletPool); // Hubungkan peluru ke pool
            }
        }
    }
}
