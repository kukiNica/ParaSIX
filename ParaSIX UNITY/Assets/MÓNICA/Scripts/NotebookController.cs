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

    void Start()
    {
        notebookUI.gameObject.SetActive(false);
    }

    void Update()
    {
        
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
