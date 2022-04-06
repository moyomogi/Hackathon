using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System.Linq;

public static class LoadManager
{
    public static void Load()
    {
        string saveFolderPath = Application.persistentDataPath + "/save";
        string saveFilePath = saveFolderPath + "/data.dat";

        // Init
        GameManager.instance.Init();

        if (!File.Exists(saveFilePath))
        {
            Debug.Log("No save data file.");
            SceneManager.LoadScene("DemoScene");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(saveFilePath, FileMode.Open);

        // Input
        SaveData saveData = (SaveData)bf.Deserialize(file);

        Debug.Log("Transition to " + saveData.sceneName);
        SceneManager.LoadScene(saveData.sceneName);

        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameManager.instance.playerPosition = saveData.playerPosition;
        GameManager.instance.playerLevel = saveData.playerLevel;
        GameManager.instance.gemsNum = saveData.gemsNum;
        GameManager.instance.obtainedGemNames = saveData.obtainedGemNames;
        GameManager.instance.questIsDone = saveData.questIsDone;

        file.Close();

        GameManager.instance.shouldRepositionPlayer = true;
    }
}
