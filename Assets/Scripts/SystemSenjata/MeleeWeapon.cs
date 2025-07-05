using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] Collider hitbox;
    Animator animator;
    float nextAttackTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        hitbox.enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Time.time >= nextAttackTime)
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Swing");
        nextAttackTime = Time.time + weaponData.fireRate;
    }

    public void EnableHitbox()
    {
        hitbox.enabled = true;
    }

    public void DisableHitbox()
    {
        hitbox.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(weaponData.damage);
            }
        }
    }

}
