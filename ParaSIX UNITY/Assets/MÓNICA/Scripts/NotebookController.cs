using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotebookController : MonoBehaviour
{
    public Button buttonOpenNOTEBOOK;
    public Button buttonCloseNOTEBOOK;

    public GameObject notebook;

    void Start()
    {
        notebook.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void OpenNOTEBOOK()
    {
        buttonOpenNOTEBOOK.gameObject.SetActive(false);
        notebook.SetActive(true);
    }

    public void CloseNOTEBOOK()
    {
        notebook.SetActive(false);
        buttonOpenNOTEBOOK?.gameObject.SetActive(true);
    }
}
