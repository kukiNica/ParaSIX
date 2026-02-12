using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Level1Controller : MonoBehaviour
{
    //GAME
    public GameObject game;
    [Space]

    //TALK
    public Button buttonTalk;
    public GameObject area;
    public GameObject player;
    public GameObject talk;

    public static float distance;
    public static bool isClose = false;
    [Space]

    //PC
    public Button buttonPC;
    public GameObject areaPC;
    public GameObject PC;

    public static float distancePC;
    public static bool isClosePC = false;
    [Space]

    //DECIDE
    public GameObject decidePanel;
    public GameObject decidePanelMini;
    [Space]

    public GameObject confirmar;
    public GameObject killFINAL;
    public GameObject liveFINAL;
    [Space]

    //QUESTIONS
    public GameObject questionsCanvas;

    //CHARACTERS
    int cont = 0;
    public TMP_Text textCont;
    [Space]

    public static AppereanceLVL1 patientNum;
    public AppereanceLVL1 patient1;
    public AppereanceLVL1 patient2;
    public AppereanceLVL1 patient3;
    [Space]

    public Button buttonkill;
    public Button buttonlive;

    public Image appereanceBackground;
    public Image questionsBackground;

    void Start()
    {
        patientNum = patient1;

        talk.SetActive(false);
        PC.gameObject.SetActive(false);

        decidePanel.SetActive(false);

        appereanceBackground.sprite = patientNum.patientBG;
        questionsBackground.sprite = patientNum.patientBG;
    }

    void Update()
    {
        distance = Vector2.Distance(area.transform.position, player.transform.position);
        distancePC = Vector2.Distance(areaPC.transform.position, player.transform.position);

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

    public void AddChars()
    {
        cont++;
        textCont.text = (cont + 1) + "/3";

        if (cont == 3)
        {
            GameController.LVL2Unlocked = true;
            SceneManager.LoadScene("Map");
        }
    }
    public static void UnlockLVL2()
    {
        GameController.LVL2Unlocked = true;
        SceneManager.LoadScene("Map");
    }

    public void OpenDecidePanel()
    {
        if (decidePanel.activeInHierarchy)
        {
            decidePanel.SetActive(false);

            decidePanelMini.SetActive(true);
        }
        else
        {
            decidePanel.SetActive(true);
            confirmar.SetActive(false);

            decidePanelMini.SetActive(false);
        }
    }
    public void KillButtonFINAL()
    {
        Debug.Log("kill");
        if (patientNum == patient1)
        {
            patientNum = patient2;

            questionsCanvas.SetActive(false);
            confirmar.SetActive(false);
            decidePanel.SetActive(false);
            game.SetActive(true);
        }
        else if (patientNum == patient2)
        {
            patientNum = patient3;

            questionsCanvas.SetActive(false);
            confirmar.SetActive(false);
            decidePanel.SetActive(false);
            game.SetActive(true);
        }
        else if (patientNum == patient3)
        {
            GameController.LVL3Unlocked = true;
            GameController.LVL1Unlocked = false;

            SceneManager.LoadScene("Map");
        }
    }

    public void LiveButtonFINAL()
    {
        Debug.Log("live");
        if (patientNum == patient1)
        {
            patientNum = patient2;

            questionsCanvas.SetActive(false);
            confirmar.SetActive(false);
            decidePanel.SetActive(false);
            game.SetActive(true);
        }
        else if (patientNum == patient2)
        {
            patientNum = patient3;

            questionsCanvas.SetActive(false);
            confirmar.SetActive(false);
            decidePanel.SetActive(false);
            game.SetActive(true);
        }
        else if (patientNum == patient3)
        {
            GameController.LVL3Unlocked = true;
            GameController.LVL1Unlocked = false;

            SceneManager.LoadScene("Map");
        }
    }

    public void DieGO()
    {
        if (confirmar.activeInHierarchy)
        {
            confirmar.SetActive(false);
        }
        else
        {
            confirmar.SetActive(true);
            killFINAL.SetActive(true);
            liveFINAL.SetActive(false);
        }
    }

    public void LiveGO()
    {
        if (confirmar.activeInHierarchy)
        {
            confirmar.SetActive(false);
        }
        else
        {
            confirmar.SetActive(true);
            killFINAL.SetActive(false);
            liveFINAL.SetActive(true);
        }
    }
}
