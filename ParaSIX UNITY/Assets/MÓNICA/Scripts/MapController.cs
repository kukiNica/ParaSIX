using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public Button buttonLVL1;
    public Button buttonLVL2;
    public Button buttonLVL3;

    void Start()
    {
        //MAP SCENE
        if (GameController.LVL2Unlocked == false)
        {
            buttonLVL2.gameObject.SetActive(false);
        }
        else
        {
            buttonLVL2.gameObject.SetActive(true);
        }

        if (GameController.LVL3Unlocked == false)
        {
            buttonLVL3.gameObject.SetActive(false);
        }
        else
        {
            buttonLVL3.gameObject.SetActive(true);
        }
    }
}
