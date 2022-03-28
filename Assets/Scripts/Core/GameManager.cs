using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ゲームマネージャーを作ってみよう https://youtu.be/JyrBl-06FAs?list=PLED8667EEZ9aB72WVMHfRHBd6oj9vplRy
    // GameManager とは、グローバル変数置き場です。
    public static GameManager instance { get; private set; }
    // public static GameManager instance = null;  // 等価
    public int playerLevel = 1;
    public int gemsNum = 0;

    public bool[] questIsDone = new bool[5];

    // Usage:
    //   GameManager.instance.gemsNum++;
    //   のように、GetComponent などをせずとも変数を指定可能。
    private void Awake()
    {
        // GameManager: シーンが変わっても保持される singleton
        if (!instance)
        {
            // 未生成
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 生成済み
            Destroy(gameObject);
        }
    }

    public void Intailize()
    {
        GameManager.instance.playerLevel = 1;
        GameManager.instance.gemsNum = 0;
        for (var i = 0; i < 5; i++)
        {
            GameManager.instance.questIsDone[i] = false;
        }
    }
    /*private void Update()
    {
        // デバッグ用 S キーセーブ
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveManager.Save();
        }
    }*/

 
}
