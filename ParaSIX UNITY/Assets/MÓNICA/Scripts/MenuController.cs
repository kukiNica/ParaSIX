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
        canvaSettings.enabled = false;
    }

    public void ResumeGame()
    {

    }

    public void StartGame()
    {

    }

    public void OpenSettings()
    {
        canvaSettings.enabled = true;
        canvaMenu.enabled = false;
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
