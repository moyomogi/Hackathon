using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // https://gametukurikata.com/ui/textmeshpro

public class GameplayUIController : MonoBehaviour
{
    // https://youtu.be/Udfmm8J8SPI?list=PLED8667EEZ9aB72WVMHfRHBd6oj9vplRy
    TextMeshProUGUI gemsNumText = null;
    int prevGemsNum = 0;
    void Start()
    {
        if (GameManager.instance == null)
        {
            Debug.LogWarning("GameManager íuÇ´ñYÇÍÇƒÇÈÇÊÅI");
            Destroy(this);
            return;
        }
        gemsNumText = GameObject.Find("GemsNumText").GetComponent<TextMeshProUGUI>();
        if (gemsNumText == null)
        {
            Debug.LogWarning("gemsNumText == null");
            Destroy(this);
            return;
        }
        gemsNumText.SetText($"Gems {GameManager.instance.gemsNum}");

    }
    void Update()
    {
        if (prevGemsNum != GameManager.instance.gemsNum)
        {
            // Update
            gemsNumText.SetText($"Gems {GameManager.instance.gemsNum}");
            prevGemsNum = GameManager.instance.gemsNum;
        }
    }
}
