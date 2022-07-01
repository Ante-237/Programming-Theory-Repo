using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class datamanager : MonoBehaviour
{
    public static datamanager instance;


    public string playerName;
    public string playerPoints;
    public int selectedPlayer = 1;
    public bool showHelp = true;
    public float difficulty = 0;
    public int highScore = 300;
    public string high_player = "Ante";


    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string playerPoints;
        public int selectedPlayer = 0;
        public int highScore = 300;
        public string high_player = "Ante";
        public bool showHelp = true;
        public float difficulty = 0;
    }

    public void StoreData()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.playerPoints = playerPoints;
        data.selectedPlayer = selectedPlayer;
        data.showHelp = showHelp;
        data.highScore = highScore;
        data.high_player = high_player;
        data.difficulty = difficulty; 
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }


    public void LoadData()
    {
        string path = Application.persistentDataPath + "/saveData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            playerPoints = data.playerPoints;
            selectedPlayer = data.selectedPlayer;
            showHelp = data.showHelp;
            highScore = data.highScore;
            high_player = data.high_player;
            difficulty = data.difficulty;
        }
    }


    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData(); 
    }


}
