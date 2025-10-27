using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour
{
    public GameObject game;
    public GameObject computerCanvas;

    public Button buttonClosePC;

    bool isOpenPC = false;

    void Start()
    {
        computerCanvas.SetActive(false);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && isOpenPC == false && Level1Controller.isClosePC == true)
        {
            OpenPC();
        }
        else if ((Input.GetKeyDown(KeyCode.E)) && isOpenPC == true)
        {
            ClosePC();
        }
    }

    public void OpenPC()
    {
        computerCanvas.gameObject.SetActive(true);
        game.gameObject.SetActive(false);

        isOpenPC = true;
    }

    public void ClosePC()
    {
        computerCanvas.gameObject.SetActive(false);
        game.gameObject.SetActive(true);

        isOpenPC = false;
    }
}
