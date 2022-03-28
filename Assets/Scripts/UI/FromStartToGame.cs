using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromStartToGame : MonoBehaviour
{
    bool clicked = false;
    public void Click()
    {
        if (clicked) return;  // ƒ{ƒ^ƒ“‚Ì˜A‘Å‘Îô
        clicked = true;
        Debug.Log("DemoScene");
        SceneManager.LoadScene("DemoScene");
    }
}

