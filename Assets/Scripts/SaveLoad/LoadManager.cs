
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class LoadManager
{
    public static void Load()
    {
        string saveFolderPath = Application.persistentDataPath + "/save";
        string saveFilePath = saveFolderPath + "/data.dat";
        if (!File.Exists(saveFilePath))
        {
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(saveFilePath, FileMode.Open);

        // Input
        SaveData saveData = (SaveData)bf.Deserialize(file);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameManager.instance.playerPosition = saveData.playerPosition;
        GameManager.instance.playerLevel = saveData.playerLevel;
        GameManager.instance.gemsNum = saveData.gemsNum;

        file.Close();

        GameManager.instance.shouldRepositionPlayer = true;
        Debug.Log("Transition to " + saveData.sceneName);
        SceneManager.LoadScene(saveData.sceneName);
    }
}
