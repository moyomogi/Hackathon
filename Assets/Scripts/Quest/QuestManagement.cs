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

        questList[0] = new Quest("Jump", "10ńWvđs¤");
        questList[1] = new Quest("Kill", "1ĚGđ|ˇ");
        questList[2] = new Quest("Slide", "3ńXCfBOđs¤");
        questList[3] = new Quest("WallRun", "3ńÇčđˇé");
        questList[4] = new Quest("Gem", "5ÂWFđćžˇé");

        for (var i = 0; i < totalQuestNum; i++)
        {
            Debug.Log(questList[i].GetTitle() + ":" + questList[i].GetInformation());
        }


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Show(0);
            questUI.SetActive(!questUI.activeSelf);
        }
    }

    public void SetQuestFlag(int n)
    {
        GameManager.instance.questIsDone[n] = true;
    }

    public bool IsQuestFlag(int n)
    {
        return GameManager.instance.questIsDone[n];
    }

    public Quest GetQuest(int n)
    {
        return questList[n];
    }

    public int GetTotalQuestNum()
    {
        return totalQuestNum;
    }

    public void Show(int n)
    {
        questInstanceList = new Transform[num];
        for (var i = 0; i < num; i++)
        {
            questInstanceList[i] = transform.Find("QuestUI/BackGround/QuestSet/Quest" + i);

            var toggleCom = questInstanceList[i].Find("TitlePanel/Toggle").GetComponent<Toggle>();
            var toggleTextCom = questInstanceList[i].Find("TitlePanel/Toggle/Label").GetComponent<Text>();
            var informationTextCom = questInstanceList[i].Find("InformationPanel/Information").GetComponent<Text>();

            var questNum = i;

            if (questNum < GetTotalQuestNum())
            {
                var check = IsQuestFlag(questNum);
                var title = GetQuest(questNum).GetTitle();
                var info = GetQuest(questNum).GetInformation();

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
