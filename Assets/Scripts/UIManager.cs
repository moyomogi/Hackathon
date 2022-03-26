using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider hpSlider;

    public Text levelText;
    public Text levelUpExplainText;

    //https://qiita.com/tokoroten_346/items/ea61b8ec215a6f60e187

    public void UpdateHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void UpdatePlayerLevelUI(int playerLevel)
    {
        if (playerLevel >= 6) levelText.text = "MAX";
        else levelText.text = playerLevel.ToString();
    }

    public void LevelUpExplainText( string info)
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
