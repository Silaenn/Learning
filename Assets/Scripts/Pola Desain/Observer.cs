using System;
using UnityEngine;

public class PlayerHealthh : MonoBehaviour
{
    public event Action<int> OnHealthChanged;
    int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        OnHealthChanged?.Invoke(health);
        Debug.Log("Player Health: " + health);
    }
}
public class Observer : MonoBehaviour
{
    [SerializeField] PlayerHealthh playerHealthh;

    void OnEnable()
    {
        playerHealthh.OnHealthChanged += UpdateHealthUI;
    }

    void OnDisable()
    {
        playerHealthh.OnHealthChanged -= UpdateHealthUI;
    }

    void UpdateHealthUI(int health)
    {
        Debug.Log("UI Updated with Health: " + health);
    }
}