using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Controller : MonoBehaviour
{
    public Button buttonTalk;
    public GameObject area;
    public GameObject player;
    public GameObject talk;

    public static float distance;
    public static bool isClose = false;

    void Start()
    {
        talk.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(area.transform.position, player.transform.position);

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
    }

    public void ActiveTalk()
    {
        talk.gameObject.SetActive(true);
    }

    public void CloseTalk()
    {
        talk.gameObject.SetActive(false);
    }
}
