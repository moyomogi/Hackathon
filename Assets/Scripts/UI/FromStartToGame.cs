using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromStartToGame : MonoBehaviour
{
    bool clicked = false;
    public void Click()
    {
        GameManager.instance.playerLevel = 1;
        GameManager.instance.gemsNum = 0;
        for (var i = 0; i < 5; i++)
        {
<<<<<<< Updated upstream
            GameManager.instance.questIsDone[i] = false;
=======
            GameManager.instance.playerLevel = 1;
            GameManager.instance.gemsNum = 0;
            for (var i = 0; i < 5; i++)
            {
                GameManager.instance.questIsDone[i] = false;
            }
            Debug.Log("New button clicked");
            SceneManager.LoadScene("DemoScene");
>>>>>>> Stashed changes
        }
        if (clicked) return;  // ƒ{ƒ^ƒ“‚Ì˜A‘Å‘Îô
        clicked = true;
        Debug.Log("DemoScene");
        SceneManager.LoadScene("DemoScene");

    }
}

