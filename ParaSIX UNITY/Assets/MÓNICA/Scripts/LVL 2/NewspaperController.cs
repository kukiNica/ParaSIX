using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewspaperController : MonoBehaviour
{
    public GameObject game;
    public GameObject newspaperUI;

    public Button buttonOpenNEWSPAPER;
    public Button buttonCloseNEWSPAPER;

    public GameObject distanceNewspaper;
    public GameObject player;

    float distance;

    void Start()
    {
        newspaperUI.SetActive(false);
    }

    private void Update()
    {
        distance = Vector2.Distance(distanceNewspaper.transform.position, player.transform.position);

        if (distance < 1.9f)
        {
            buttonOpenNEWSPAPER.gameObject.SetActive(true);
        }
        else
        {
            buttonOpenNEWSPAPER.gameObject.SetActive(false);
        }
    }

    public void OpenNewspaper()
    {
        newspaperUI.SetActive(true);
        game.SetActive(false);
    }

    public void CloseNewspaper()
    {
        newspaperUI.SetActive(false);
        game.SetActive(true);
    }
}
