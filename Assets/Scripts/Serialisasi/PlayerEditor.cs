using System.Collections.Generic;
using UnityEngine;

public class PlayerEditor : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private List<string> inventory;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
    }
}