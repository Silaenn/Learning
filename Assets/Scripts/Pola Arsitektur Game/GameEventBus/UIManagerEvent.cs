using TMPro;
using UnityEngine;

public class UIManagerEvent : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;
    int currentScore;
    int currentHealth = 100;

    void OnEnable()
    {
        GameEventBus.OnCoinColledted += UpdateScore;
        GameEventBus.OnPlayerDamaged += UpdateHealth;
    }

    void UpdateScore(int score)
    {
        currentScore += score;
        scoreText.text = $"Score: {currentScore}";
    }

    void UpdateHealth(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        healthText.text = $"Health: {currentHealth}";
    }
}
