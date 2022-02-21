using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class InputManager : MonoBehaviour
{
    public static InputManager Instace;
    public string nameText;
    public int highScore;

    // MainシーンからMainMenuシーンへの遷移ができないためシングルトンを採用していません。
    private void Awake()
    {
        Instace = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayer();
    }

    // セッション間のデータ永続性
    [Serializable]
    class SaveData
    {
        public string nameText;
        public int highScore;
    }

    public void SavePlayer()
    {
        SaveData saveData = new SaveData();
        saveData.nameText = nameText;
        saveData.highScore = highScore;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            nameText = saveData.nameText;
            highScore = saveData.highScore;
        }
    }
}
