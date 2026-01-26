using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotebookController : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject notebookUI;
    
    public Button buttonOpenNOTEBOOK;
    public Button buttonCloseNOTEBOOK;

    public GameObject distanceNotebook;
    public GameObject player;

    float distance;

    void Start()
    {
        notebookUI.gameObject.SetActive(false);
    }

    void Update()
    {
        distance = Vector2.Distance(distanceNotebook.transform.position, player.transform.position);

        if (distance < 1.9f)
        {
            buttonOpenNOTEBOOK.gameObject.SetActive(true);
        }
        else
        {
            buttonOpenNOTEBOOK.gameObject.SetActive(false);
        }
    }

    public void OpenNOTEBOOK()
    {
        notebookUI.SetActive(true);

        gameUI.SetActive(false);
    }

    public void CloseNOTEBOOK()
    {
        notebookUI.SetActive(false);
        gameUI.SetActive(true);
    }
}
