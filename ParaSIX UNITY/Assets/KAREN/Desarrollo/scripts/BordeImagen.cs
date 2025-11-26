using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordeImagen : MonoBehaviour
{
   
    public GameObject outline;

    void Start()
    {
        outline.SetActive(false);
    }

    void OnMouseEnter()
    {
        outline.SetActive(true);
    }

    void OnMouseExit()
    {
        outline.SetActive(false);
    }
}


