using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromStartToGame : MonoBehaviour
{
    [Header("Whether this is a load button")] public bool isLoadButton = true;
    bool clicked = false;
    public void Click()
    {
        if (clicked) return;  // é€£æ‰“å¯¾ç­–
        clicked = true;
        if (isLoadButton)
        {
            Debug.Log("Load button clicked");
            LoadManager.Load();
        }
        else
        {
            Debug.Log("New button clicked");
            SceneManager.LoadScene("DemoScene");
        }
    }
}
