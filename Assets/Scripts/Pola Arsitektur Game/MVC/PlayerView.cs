using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;

    public void UpdateDisplay(int score, int health)
    {
        scoreText.text = $"Score: {score}";
        healthText.text = $"Health: {health}";
    }
}
