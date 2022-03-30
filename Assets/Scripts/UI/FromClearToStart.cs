using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromClearToStart : MonoBehaviour
{
    bool clicked = false;
    public void Click()
<<<<<<< Updated upstream
    {

        
        if (clicked) return;  // �{�^���̘A�ő΍�
=======
    { 
        if (clicked) return;  // ƒ{ƒ^ƒ“‚Ì˜A‘Å‘Îô
>>>>>>> Stashed changes
        clicked = true;
        Time.timeScale = 1;
        Debug.Log("TitleScene");
        SceneManager.LoadScene("TitleScene");
<<<<<<< Updated upstream
        GameManager.instance.playerLevel = 1;
        GameManager.instance.gemsNum = 0;
        for (var i = 0; i < 5; i++)
        {
            GameManager.instance.questIsDone[i] = false;
        }
=======
>>>>>>> Stashed changes
    }
}
