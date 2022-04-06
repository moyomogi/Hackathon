using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Slider hpSlider;

    public TextMeshProUGUI playerLevelText;
    public Text levelUpExplainText;

    // https://qiita.com/tokoroten_346/items/ea61b8ec215a6f60e187
    public void UpdateHP(int hp)
    {
        hpSlider.value = hp;
    }
    public void UpdatePlayerLevelUI(int playerLevel)
    {
        if (GameManager.instance.playerLevel >= 6)
        {
            playerLevelText.text = "PlayerLevel MAX";
        }
        else
        {
            playerLevelText.text = $"PlayerLevel {GameManager.instance.playerLevel}";
        }
    }
    public void LevelUpExplainText(string info)
    {
        levelUpExplainText.text = info;
        StartCoroutine("TextSet");
    }
    IEnumerator TextSet()
    {
        yield return new WaitForSeconds(1.0f);
        levelUpExplainText.text = "";
    }
}
