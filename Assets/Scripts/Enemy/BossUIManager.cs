using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUIManager : MonoBehaviour
{
    public Slider hpSlider;

    public void UpdateBossHP(int hp)
    {
        hpSlider.value = hp;
    }
}
