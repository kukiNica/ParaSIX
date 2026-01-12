using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVL2Controller : MonoBehaviour
{
    public void SceneMAP()
    {
        GameController.LVL3Unlocked = true;
        SceneManager.LoadScene("Map");
    }
}
