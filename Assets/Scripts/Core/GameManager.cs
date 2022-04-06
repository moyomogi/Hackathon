using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    // �Q�[���}�l�[�W���[������Ă݂悤 https://youtu.be/JyrBl-06FAs?list=PLED8667EEZ9aB72WVMHfRHBd6oj9vplRy
    // GameManager �Ƃ́AScene ���ړ����Ă����ł��������Ȃ��ϐ���u���ꏊ�ł��B
    public static GameManager instance { get; private set; }
    // public static GameManager instance = null;  // ����

    // When the game is loaded, reposition the player
    public bool shouldRepositionPlayer = false;

    public float[] playerPosition = new float[3];
    public int playerLevel = 1;
    public int gemsNum = 0;
    public List<string> obtainedGemNames = new List<string>();

    public bool[] questIsDone = new bool[5];
    public bool shouldLoad = false;

    // Usage:
    //   GameManager.instance.gemsNum++;
    //   �̂悤�ɁAGetComponent �����Ƃ��ϐ����w��\�B
    private void Awake()
    {
        // GameManager: �V�[�����ς���Ă��ێ������ singleton
        if (!GameManager.instance)
        {
            // ������
            GameManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // �����ς�
            Destroy(gameObject);
        }
    }

    public void Init()
    {
        // Init
        GameManager.instance.shouldRepositionPlayer = false;
        for (int i = 0; i < 3; i++)
        {
            GameManager.instance.playerPosition[i] = 0.0f;
        }
        GameManager.instance.playerLevel = 1;
        GameManager.instance.gemsNum = 0;
        for (int i = 0; i < 5; i++)
        {
            GameManager.instance.questIsDone[i] = false;
        }
        GameManager.instance.obtainedGemNames = new List<string>();
        GameManager.instance.shouldLoad = false;
    }
    private void Update()
    {
        // If there is no save data file, save the game
        if (!File.Exists(Application.persistentDataPath + "/save/data.dat"))
        {
            SaveManager.Save();
            return;
        }

        // Press F2 to return to title scene
        if (Input.GetKeyDown(KeyCode.F2))
        {
            // Load TitleScene.unity
            SceneManager.LoadScene("TitleScene");
            return;
        }
        // Press ESC to quit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            return;
        }
#if UNITY_EDITOR
        // P �� Save (For debugging)
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveManager.Save();
        }
#endif
        // R �� Retry
        if (Input.GetKeyDown(KeyCode.R) || GameManager.instance.shouldLoad)
        {
            LoadManager.Load();
        }
    }
}
