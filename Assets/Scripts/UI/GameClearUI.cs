
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameClearUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText = null;
    public AudioSource BGM;
    void Start()
    {
        if (GameManager.instance == null)
        {
            Debug.LogWarning("GameManager");
            Destroy(this);
            return;
        }
        if (scoreText == null)
        {
            Debug.LogWarning("gemsNumText == null");
            Destroy(this);
            return;
        }
        scoreText.SetText($"Score : {GameManager.instance.playerLevel * 1000 + GameManager.instance.gemsNum * 100}");
        BGM.volume = 0;
    }
}
