using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public delegate void GameStartHandler();
    public event GameStartHandler OnGameStart;

    [SerializeField] Button startButton;
    [SerializeField] Button pauseButton;
    [SerializeField] Button quitButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        pauseButton.onClick.AddListener(PauseGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        Debug.Log("Game dimulai!");
        OnGameStart?.Invoke();
    }

    void PauseGame()
    {
        Debug.Log("Game dipause");
        Time.timeScale = 0;
    }

    void QuitGame()
    {
        Debug.Log("Keluar dari game");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void OnOestroy()
    {
        startButton.onClick.RemoveAllListeners();
        pauseButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
    }
}
