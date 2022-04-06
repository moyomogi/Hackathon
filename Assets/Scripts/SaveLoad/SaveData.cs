using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

// How to Build A Save System in Unity https://youtu.be/5roZtuqZyuw
// SAVE & LOAD SYSTEM in Unity https://youtu.be/XOjd_qU2Ido
[System.Serializable]
public class SaveData
{
    // 保存すべき内容は
    // - player.transform.position
    // - GameManager.instance.playerLevel
    // - GameManager.instance.gemsNum
    public float[] playerPosition = new float[3];
    public int playerLevel = 1;
    public string sceneName = "";
    public int gemsNum = 0;
    public List<string> obtainedGemNames = new List<string>();
    public bool[] questIsDone = new bool[5];
    public SaveData()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("(SaveData) Player タグの付いた GameObject が見つかりませんでした");
        }
        else
        {
            playerPosition = new float[3];
            playerPosition[0] = player.transform.position.x;
            playerPosition[1] = player.transform.position.y;
            playerPosition[2] = player.transform.position.z;
        }
        // sceneName = SceneManager.GetActiveScene().name;
        // playerLevel = GameManager.instance.playerLevel;
        // gemsNum = GameManager.instance.gemsNum;
        // obtainedGemNames = GameManager.instance.obtainedGemNames;
        // questIsDone = GameManager.instance.questIsDone;
    }
}
