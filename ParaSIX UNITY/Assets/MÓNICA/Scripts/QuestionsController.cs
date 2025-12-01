using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsController : MonoBehaviour
{
    public GameObject game;

    public GameObject panelQuestions;

    public GameObject appereanceCanva;

    public static bool isOpenQUESTIONS = false;

    void Start()
    {
        panelQuestions.SetActive(false);
        isOpenQUESTIONS = false;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && isOpenQUESTIONS == false && Level1Controller.isClose == true)
        {
            OpenQUESTIONS();
        }
        else if ((Input.GetKeyDown(KeyCode.E)) && isOpenQUESTIONS == true)
        {
            CloseQUESTIONS();
        }
    }

    public void OpenQUESTIONS()
    {
        panelQuestions.SetActive(true);
        isOpenQUESTIONS = true;

        game.SetActive(false);
    }

    public void CloseQUESTIONS()
    {
        panelQuestions.SetActive(false);
        isOpenQUESTIONS = false;

        game.SetActive(true);

        appereanceCanva.SetActive(false);
        AppereanceController.isOpenAP = false;
    }
}
