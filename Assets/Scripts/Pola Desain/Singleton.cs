using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; set; }
    public int score = 0;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Current Score: " + score);
    }

}
