using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button buttonResume;
    public Button buttonStartGame;
    public Button buttonSettings;
    public Button buttonCredits;
    public Button buttonExit;

    public Canvas canvaMenu;
    public Canvas canvaSettings;

    void Start()
    {
        PlayerPrefs.GetInt("unlocked2", 0);
        PlayerPrefs.GetInt("unlocked3", 0);
    }

    public void ResumeGame()
    {

    }

    public void StartGame()
    {

    }

    public void OpenSettings()
    {
        
    }

    public void OpenCredits()
    {

    }

    public void CloseCredits()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
