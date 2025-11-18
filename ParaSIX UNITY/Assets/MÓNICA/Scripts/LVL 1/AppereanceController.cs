using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppereanceController : MonoBehaviour
{
    public GameObject appereanceCanva;
    public GameObject questionsCanva;

    public Image pic;
    public Sprite spriteLF;
    public Sprite spriteRF;
    public Sprite spriteLH;
    public Sprite spriteRH;
    public Sprite spriteHead;

    public static bool isOpenAP;

    void Start()
    {
        appereanceCanva.SetActive(false);
        isOpenAP = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && (isOpenAP == false) && (QuestionsController.isOpenQUESTIONS == true)) 
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
            pic.sprite = spriteLH;
        }
        else if (type == "RightHand")
        {
            pic.sprite = spriteRH;
        }
        else if (type == "LeftFoot")
        {
            pic.sprite = spriteLF;
        }
        else if (type == "RightFoot")
        {
            pic.sprite = spriteRF;
        }
        else if (type == "Head")
        {
            pic.sprite = spriteHead;
        }
    }
}
