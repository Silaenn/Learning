using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] Collider hitbox;
    Animator animator;
    float nextAttackTime;
    bool isAttacking;

    void Start()
    {
        animator = GetComponent<Animator>();
        hitbox.enabled = false;
        isAttacking = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Time.time >= nextAttackTime && !isAttacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        isAttacking = true;
        animator.SetTrigger("Swing"); // Gunakan Trigger, bukan Bool
        nextAttackTime = Time.time + weaponData.fireRate;
    }

    // Dipanggil oleh Animation Event di akhir animasi
    public void EndAttack()
    {
        isAttacking = false;
        animator.ResetTrigger("Swing"); // Reset Trigger untuk jaga-jaga
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