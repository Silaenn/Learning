using UnityEngine;

public class EnemyLedakan : MonoBehaviour
{
    public GameObject explosionEffect; // Prefab Particle System

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Instansiasi efek ledakan
            Debug.Log("Masuk");
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject); // Hancurkan musuh
        }
    }
}
