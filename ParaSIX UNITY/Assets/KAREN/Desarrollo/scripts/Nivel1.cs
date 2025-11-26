using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel1 : MonoBehaviour
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

    void Start()
    {
        talk.SetActive(false);
        PC.gameObject.SetActive(false);
    }

    void Update()
    {
        distance = Vector2.Distance(area.transform.position, player.transform.position);
        distancePC = Vector2.Distance(areaPC.transform.position, player.transform.position);

        //TALK
        if (distance <= 1.9f)
        {
            ActiveTalk();
            isClose = true;
        }
        else
        {
            CloseTalk();
            isClose = false;
        }

        //PC
        if (distancePC <= 1.9f)
        {
            ActivePC();
            isClosePC = true;
        }
        else
        {
            ClosePCDistance();
            isClosePC = false;
        }
    }

    public void ActiveTalk()
    {
        talk.SetActive(true);
    }

    public void CloseTalk()
    {
        talk.SetActive(false);
    }

    public void ActivePC()
    {
        PC.gameObject.SetActive(true);
    }

    public void ClosePCDistance()
    {
        PC.gameObject.SetActive(false);
    }
}
