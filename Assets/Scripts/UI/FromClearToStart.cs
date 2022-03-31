using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromClearToStart : MonoBehaviour
{
    bool clicked = false;
    public void Click()
    {
        if (clicked) return;
        clicked = true;
        Time.timeScale = 1;
        Debug.Log("TitleScene");
        SceneManager.LoadScene("TitleScene");
    }
}
