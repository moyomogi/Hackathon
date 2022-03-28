
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
        if (player == null)
        {
            Debug.LogError("(LoadManager) Player ƒ^ƒO‚Ì•t‚¢‚½ GameObject ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ‚Å‚µ‚½");
        }
        else
        {
            player.transform.position = new Vector3(saveData.playerPosition[0], saveData.playerPosition[1], saveData.playerPosition[2]);
        }
        GameManager.instance.playerLevel = saveData.playerLevel;
        GameManager.instance.gemsNum = saveData.gemsNum;

        file.Close();
    }
}