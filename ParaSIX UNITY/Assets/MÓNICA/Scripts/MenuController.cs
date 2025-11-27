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

    public void ExitGame()
    {
        Application.Quit();
    }
}
