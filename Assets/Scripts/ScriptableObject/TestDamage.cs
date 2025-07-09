using UnityEngine;

public class TestDamage : MonoBehaviour
{
    [SerializeField] private PlayerHealthSO player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.TakeDamage(10); // Simulasi damage
        }
    }
}