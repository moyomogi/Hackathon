using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class SaveManager
{
    public static void Save()
    {
        string saveFolderPath = Application.persistentDataPath + "/save";
        if (!Directory.Exists(saveFolderPath))
        {
            Directory.CreateDirectory(saveFolderPath);
        }
        string saveFilePath = saveFolderPath + "/data.dat";
        Debug.Log("Save to " + saveFilePath);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(saveFilePath);

        // セーブデータ取得
        SaveData saveData = new SaveData();
        saveData.sceneName = SceneManager.GetActiveScene().name;
        saveData.playerLevel = GameManager.instance.playerLevel;
        saveData.gemsNum = GameManager.instance.gemsNum;
        saveData.obtainedGemNames = GameManager.instance.obtainedGemNames;
        saveData.questIsDone = GameManager.instance.questIsDone;
        string s = "";
        foreach (string name in saveData.obtainedGemNames)
        {
            s += name + " ";
        }
        Debug.Log("SaveData: " + s);

        // Output
        bf.Serialize(file, saveData);
        file.Close();
    }
}
