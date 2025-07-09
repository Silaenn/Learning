using UnityEngine;

public class BulletPooll : MonoBehaviour
{
   public float speed = 10f;
    private ObjectPooling pool;

    public void SetPool(ObjectPooling pool)
    {
        this.pool = pool;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // Kembalikan ke pool jika keluar layar (misalnya)
        if (transform.position.z > 20f)
        {
            pool.ReturnBullet(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Kembalikan ke pool saat mengenai sesuatu
        pool.ReturnBullet(gameObject);
    }
}
