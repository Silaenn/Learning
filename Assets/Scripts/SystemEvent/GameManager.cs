using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        UIManager uIManager = FindAnyObjectByType<UIManager>();

        if (uIManager != null)
        {
            uIManager.OnGameStart += InitializeGame;
        }
    }

    void InitializeGame()
    {
        Debug.Log("Sistem game diinisialisasi");
        Time.timeScale = 1f;
    }

    void OnDestroy()
    {
        UIManager uIManager = FindAnyObjectByType<UIManager>();

        if (uIManager != null)
        {
            uIManager.OnGameStart -= InitializeGame;
        }
    }
}
