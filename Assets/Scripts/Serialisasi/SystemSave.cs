using System.IO;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int health;
    public Vector3 position;
}

public class SystemSave : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    string savePath;

    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "playerData.json");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved: " + savePath);
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.LogWarning("No Save file found");
        }
    }
}
