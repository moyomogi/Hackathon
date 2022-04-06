using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagement : MonoBehaviour
{
    private Quest[] questList;

    [SerializeField] private int totalQuestNum = 5;

    //private bool[] questIsDone;
    private GameObject questUI;

    private int num = 5;
    private Transform[] questInstanceList;

    private void Start()
    {
        questList = new Quest[totalQuestNum];
        //questIsDone = new bool[totalQuestNum];

        questUI = transform.Find("QuestUI").gameObject;

        questList[0] = new Quest("Jump", "10回ジャンプを行う");
        questList[1] = new Quest("Kill", "1体敵を倒す");
        questList[2] = new Quest("Slide", "3回スライディングを行う");
        questList[3] = new Quest("WallRun", "3回壁走りする");
        questList[4] = new Quest("Gem", "5個ジェムを取得する");

        for (int i = 0; i < totalQuestNum; i++)
        {
            Debug.Log(questList[i].GetTitle() + ":" + questList[i].GetInformation());
        }


    }

    private void Update()
    {
        // Show Quests
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Show();
            questUI.SetActive(!questUI.activeSelf);
        }
    }

    public void SetQuestFlag(int idx)
    {
        GameManager.instance.questIsDone[idx] = true;
    }

    public bool IsQuestFlag(int idx)
    {
        return GameManager.instance.questIsDone[idx];
    }

    public Quest GetQuest(int idx)
    {
        return questList[idx];
    }

    public int GetTotalQuestNum()
    {
        return totalQuestNum;
    }

    public void Show()
    {
        questInstanceList = new Transform[num];
        for (int i = 0; i < num; i++)
        {
            questInstanceList[i] = transform.Find("QuestUI/BackGround/QuestSet/Quest" + i);

            var toggleCom = questInstanceList[i].Find("TitlePanel/Toggle").GetComponent<Toggle>();
            var toggleTextCom = questInstanceList[i].Find("TitlePanel/Toggle/Label").GetComponent<Text>();
            var informationTextCom = questInstanceList[i].Find("InformationPanel/Information").GetComponent<Text>();

            if (i < GetTotalQuestNum())
            {
                var check = IsQuestFlag(i);
                var title = GetQuest(i).GetTitle();
                var info = GetQuest(i).GetInformation();

                toggleCom.isOn = check;
                toggleTextCom.text = title;
                informationTextCom.text = info;
            }
            else
            {
                toggleCom.isOn = false;
                toggleTextCom.text = "";
                informationTextCom.text = "";
            }
        }
    }
}
