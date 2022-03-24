using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider hpSlider;
   

    //https://qiita.com/tokoroten_346/items/ea61b8ec215a6f60e187

    public void UpdateHP(int hp)
    {
        hpSlider.value = hp;
    }

}
