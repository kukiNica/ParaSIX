using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppereanceController : MonoBehaviour
{
    public GameObject appereanceCanva;
    public GameObject questionsCanva;

    public Image pic;

    public static bool isOpenAP;

    void Start()
    {
        appereanceCanva.SetActive(false);
        isOpenAP = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && (isOpenAP == false))
        {
            OpenAP();
        }
        else if (Input.GetKeyUp(KeyCode.F) && (isOpenAP == true)) 
        {
            CloseAP();
        }
    }

    public void OpenAP()
    {
        appereanceCanva.SetActive(true);
        questionsCanva.SetActive(false);

        isOpenAP = true;
    }

    public void CloseAP()
    {
        appereanceCanva.SetActive(false);
        questionsCanva.SetActive(true);

        isOpenAP = false;
    }

    public void ChangeImage(string type)
    {
        if (type == "LeftHand")
        {
            pic.sprite = Level1Controller.patientNum.leftHand;
        }
        else if (type == "RightHand")
        {
            pic.sprite = Level1Controller.patientNum.rightHand;
        }
        else if (type == "LeftFoot")
        {
            pic.sprite = Level1Controller.patientNum.leftFoot;
        }
        else if (type == "RightFoot")
        {
            pic.sprite = Level1Controller.patientNum.rightFoot;
        }
        else if (type == "Head")
        {
            pic.sprite = Level1Controller.patientNum.face;
        }
    }
}
