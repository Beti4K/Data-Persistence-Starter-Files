using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public string highScorePlayerName;
    public int highScore;

    public TextMeshProUGUI bestScore;

    public TextMeshProUGUI inputName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        DisplayHighscore();
    }

    public void NameUpdate()
    {
        playerName = inputName.text;
    }

    [System.Serializable]
    class SaveData
    {
        public string highPlayerName;
        public int highScore;
    }

    public void SaveHighscore(int score)
    {
        SaveData data = new SaveData();
        data.highPlayerName = playerName;
        data.highScore = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.highPlayerName;
            highScore = data.highScore;
        }
    }

    public void DisplayHighscore()
    {
        LoadHighscore();
        bestScore = GameObject.Find("BestScore").GetComponent<TextMeshProUGUI>();
        bestScore.text = highScore.ToString() + " (" + highScorePlayerName + ")";
    }
}
