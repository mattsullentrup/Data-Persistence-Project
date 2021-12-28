using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
[System.Serializable]

public static class SaveData
{
    public static void SaveGameData()
    {
        Debug.Log("Game Saved");

        //create our save data
        Data d = new Data();

        d.savedHighScore = MainManager.Instance.highScore;
        d.savedPlayerName = MainManager.Instance.savedPlayerNameStr;

        string saveFile = JsonUtility.ToJson(d);

        //string that contains our filepath
        string path = Application.persistentDataPath + "/savefile.json";

        if (!File.Exists(path))
        {
            File.Create(path);
        }

        StreamWriter writer = new StreamWriter(path);
        writer.Write(saveFile);
        writer.Close();
    }

    public static void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("Save Loaded");
            StreamReader r = new StreamReader(path);
            string file = r.ReadToEnd();
            Data d = JsonUtility.FromJson<Data>(file);
            MainManager.Instance.highScore = d.savedHighScore;
            MainManager.Instance.savedPlayerNameStr = d.savedPlayerName;
            r.Close();
        }
        else
            Debug.Log("No save data exists");
    }
}

public class Data
{
    public int savedHighScore;
    public string savedPlayerName;
}
