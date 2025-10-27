using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsController : MonoBehaviour
{
    public GameObject panelQuestions;

    bool isOpen = false;

    void Start()
    {
        panelQuestions.SetActive(false);
        isOpen = false;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && isOpen == false && Level1Controller.isClose == true)
        {
            OpenQUESTIONS();
        }
        else if ((Input.GetKeyDown(KeyCode.E)) && isOpen == true)
        {
            CloseQUESTIONS();
        }
    }

    public void OpenQUESTIONS()
    {
        panelQuestions.SetActive(true);
        isOpen = true;
    }

    public void CloseQUESTIONS()
    {
        panelQuestions.SetActive(false);
        isOpen = false;
    }
}
