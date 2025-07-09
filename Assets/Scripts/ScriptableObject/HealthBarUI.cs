using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    public void UpdateHealthBar()
    {
        // Logika untuk update health bar
        Debug.Log("Health bar updated!");
    }
}