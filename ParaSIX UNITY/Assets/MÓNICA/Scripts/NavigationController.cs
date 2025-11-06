using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour
{
    public Button buttonLVL1;
    public Button buttonLVL2;
    public Button buttonLVL3;

    bool LVL2Unlocked = false;
    int unlocked2;

    bool LVL3Unlocked = false;
    int unlocked3;

    void Start()
    {
        //MAP SCENE
        unlocked2 = PlayerPrefs.GetInt("unlocked2", 0);
        unlocked3 = PlayerPrefs.GetInt("unlocked3", 0);

        if (LVL2Unlocked == false)
        {
            buttonLVL2.gameObject.SetActive(false);
        }
        else
        {
            buttonLVL2.gameObject.SetActive(true);
        }

        if (LVL3Unlocked == false)
        {
            buttonLVL3.gameObject.SetActive(false);
        }
        else
        {
            buttonLVL3.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        
    }

    public void UnlockLevels()
    {
        if ((LVL2Unlocked == false) || (unlocked2 == 0))
        {
            LVL2Unlocked = true;
            PlayerPrefs.GetInt("unlocked2", 1);

            Debug.Log("NIVEL 2");
        }

        if ((LVL2Unlocked == true) || (unlocked3 == 0))
        {
            LVL3Unlocked = true;
            PlayerPrefs.GetInt("unlocked3", 1);
        }
    }

    public void SceneLVL1() //LEVEL 1
    {
        SceneManager.LoadScene("Level 1");
    }

    public void SceneLVL2() //LEVEL 2
    {
        SceneManager.LoadScene("Level 2");
    }

    public void SceneLVL3() //LEVEL 3
    {
        SceneManager.LoadScene("Level 3");
    }

    public void SceneMinigame1() //MINIGAME FROM LEVEL 1 TO 2
    {
        SceneManager.LoadScene("Minigame 1");
    }

    public void SceneMinigame2() //MINIGAME FROM LEVEL 2 TO 3
    {
        SceneManager.LoadScene("Minigame 2");
    }

    public void SceneMAP() //OPEN MAP
    {
        SceneManager.LoadScene("Map");
        
        UnlockLevels();
    }
}
