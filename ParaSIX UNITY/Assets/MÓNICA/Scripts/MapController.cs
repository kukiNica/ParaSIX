using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public Button buttonLVL1;
    public Button buttonLVL3;

    void Start()
    {
        //MAP SCENE
        if (GameController.LVL3Unlocked == false)
        {
            buttonLVL3.enabled = false;
        }
        else
        {
            buttonLVL3.enabled = true;
        }

        if (GameController.LVL1Unlocked == false)
        {
            buttonLVL1.enabled = false;
        }
        else
        {
            buttonLVL1.enabled = true;
        }
    }
}
