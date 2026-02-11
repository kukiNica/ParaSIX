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
    public GameObject decidePanel;
    public GameObject decidePanelMini;

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

        buttonkill.gameObject.SetActive(false);
        buttonlive.gameObject.SetActive(false);
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
            buttonkill.gameObject.SetActive(false);
            buttonlive.gameObject.SetActive(false);

            decidePanelMini.SetActive(true);
        }
        else
        {
            decidePanel.SetActive(true);
            buttonkill.gameObject.SetActive(true);
            buttonlive.gameObject.SetActive(true);

            decidePanelMini.SetActive(false);
        }
    }
    public void KillButton()
    {
        Debug.Log("kill");
        if (patientNum == patient1)
        {
            patientNum = patient2;
        }
        else if (patientNum == patient2)
        {
            patientNum = patient3;
        }
        else if (patientNum == patient3)
        {
            SceneManager.LoadScene("Map");
            GameController.LVL3Unlocked = true;
        }
    }

    public void LiveButton()
    {
        Debug.Log("live");
        if (patientNum == patient1)
        {
            patientNum = patient2;
        }
        else if (patientNum == patient2)
        {
            patientNum = patient3;
        }
        else if (patientNum == patient3)
        {
            GameController.LVL3Unlocked = true;
            SceneManager.LoadScene("Map");
        }
    }
}
