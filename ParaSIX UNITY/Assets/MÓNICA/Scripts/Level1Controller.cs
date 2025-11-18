using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1Controller : MonoBehaviour
{
    //GAME
    public GameObject game;

    //TALK
    public Button buttonTalk;
    public GameObject area;
    public GameObject player;
    public GameObject talk;

    public static float distance;
    public static bool isClose = false;

    //PC
    public Button buttonPC;
    public GameObject areaPC;
    public GameObject PC;

    public static float distancePC;
    public static bool isClosePC = false;

    //DECIDE
    public Button buttonDecide;
    public GameObject areaDecide;
    public GameObject decide;

    float distanceDecide;
    bool isCloseDecide = false;

    public GameObject decidePanel;
    bool isOpenDecidePanel = false;

    //CHARACTERS
    int cont = 0;

    void Start()
    {
        talk.SetActive(false);
        PC.gameObject.SetActive(false);

        decidePanel.SetActive(false);

        cont++;
    }

    void Update()
    {
        distance = Vector2.Distance(area.transform.position, player.transform.position);
        distancePC = Vector2.Distance(areaPC.transform.position, player.transform.position);
        distanceDecide = Vector2.Distance(areaDecide.transform.position, player.transform.position);

        //TALK
        if (distance <= 1.9f)
        {
            ActiveTalk();
        }
        else
        {
            CloseTalk();
        }

        //PC
        if (distancePC <= 1.9f)
        {
            ActivePC();
        }
        else
        {
            ClosePCDistance();
        }

        //DECIDE
        if (distanceDecide <= 1.9f)
        {
            ActiveDecide();
        }
        else
        {
            CloseDecide();
        }

        if (Input.GetKeyDown(KeyCode.E) && isOpenDecidePanel == false && isCloseDecide == true)
        {
            OpenDecidePanel();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOpenDecidePanel == true && isCloseDecide == true)
        {
            CloseDecidePanel();
        }
    }

    public void ActiveTalk()
    {
        talk.SetActive(true);
        isClose = true;
    }

    public void CloseTalk()
    {
        talk.SetActive(false);
        isClose = false;
    }

    public void ActivePC()
    {
        PC.gameObject.SetActive(true);
        isClosePC = true;
    }

    public void ClosePCDistance()
    {
        PC.gameObject.SetActive(false);
        isClosePC = false;
    }

    public void ActiveDecide()
    {
        decide.SetActive(true);
        isCloseDecide = true;
    }

    public void CloseDecide()
    {
        decide.SetActive(false);
        isCloseDecide = false;
    }

    public void OpenDecidePanel()
    {
        decidePanel.SetActive(true);
        Time.timeScale = 0f;
        isOpenDecidePanel = true;
    }

    public void CloseDecidePanel()
    {
        decidePanel.SetActive(false);
        Time.timeScale = 1f;
        isOpenDecidePanel = false;
    }

    public void Kill()
    {
        cont++;
        CloseDecidePanel();

        if(cont == 4)
        {
            SceneManager.LoadScene("Map");
        }
    }

    public void Alive()
    {
        cont++;
        CloseDecidePanel();

        if (cont == 4)
        {
            SceneManager.LoadScene("Map");
        }
    }
}
