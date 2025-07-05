using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 50f;
    public int damage = 10;
    [SerializeField] float lifetime = 5f;

    void OnEnable()
    {
        Invoke("Deactivate", lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Deactivate();
        }
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
