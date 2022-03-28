using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject gameoverText;
    public PlayerScript player;
    public BossScript boss;

    public GameObject gameClearUI;

    public void GameOver()
    {
        gameoverText.SetActive(true);
        Invoke("GameRestart", 1f);

    }

    public void GameClear()
    {
        //SceneManager.LoadScene("ClearScene");
        gameClearUI.SetActive(true);
    }

    public void GameRestart()
    {
        // 現在のシーンを取得してロードする
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
        //DemoSceneで死んだならLevel,GemNum,Questフラグ全部リセット
        if (SceneManager.GetActiveScene().name == "DemoScene")
        {
            GameManager.instance.playerLevel = 1;
            GameManager.instance.gemsNum = 0;
            for (var i = 0; i < 5; i++)
            {
                GameManager.instance.questIsDone[i] = false;
            }
        }
        //ボスで死んだならボス中に上がったレベルも含めリスタート（救済も兼ねて
    }

    private void Update()
    {
        if (player.getIsDead()) GameOver();
        if(SceneManager.GetActiveScene().name == "Boss_Battle")
        {
            if (boss.IsBossDead()) GameClear();
        }
    }
}
