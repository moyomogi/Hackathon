using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleMenuManager : MonoBehaviour
{
    public GameObject[] buttonObjects = new GameObject[3];
    bool newGameButtonClicked = false, loadGameButtonClicked = false, quitButtonClicked = false;
    int index = -1;
    void Awake()
    {
        // Setup buttonObjects
        buttonObjects[0] = GameObject.Find("NewGameButton");
        buttonObjects[1] = GameObject.Find("LoadGameButton");
        buttonObjects[2] = GameObject.Find("QuitButton");
    }
    private void Update()
    {
        bool isPressedLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        bool isPressedRight = Input.GetKeyDown(KeyCode.RightArrow);
        // Left
        if (isPressedLeft && !isPressedRight)
        {
            Debug.Log("Left key is pressed");
            index = index == -1 ? 0 : (index + 2) % 3;
            EventSystem.current.SetSelectedGameObject(buttonObjects[index]);
        }
        // Right
        if (!isPressedLeft && isPressedRight)
        {
            Debug.Log("Right key is pressed");
            index = index == -1 ? 0 : (index + 1) % 3;
            EventSystem.current.SetSelectedGameObject(buttonObjects[index]);
        }
    }
    // New Game
    public void OnClickNewGameButton()
    {
        // Take precautions in case the button is pressed more than once.
        if (newGameButtonClicked) return;
        newGameButtonClicked = true;
        Debug.Log("New game button is clicked");

        // Delete save data file
        File.Delete(Application.persistentDataPath + "/save/data.dat");

        GameManager.instance.Init();
        SceneManager.LoadScene("DemoScene");
    }
    // Load Game
    public void OnClickLoadGameButton()
    {
        // Take precautions in case the button is pressed more than once.
        if (loadGameButtonClicked) return;
        loadGameButtonClicked = true;
        Debug.Log("Load game button is clicked");
        LoadManager.Load();
    }
    // Exit
    public void OnClickQuitButton()
    {
        // Take precautions in case the button is pressed more than once.
        if (quitButtonClicked) return;
        quitButtonClicked = true;
        Debug.Log("Quit button is clicked");
        Application.Quit();
    }
}
