using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVL2Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject civilian;

    float distance;
    public static bool isClose;

    private void Update()
    {
        distance = Vector2.Distance(civilian.transform.position, player.transform.position);

        if (distance < 1.9f)
        {
            isClose = true;
        }
        else
        {
            isClose = false;
        }
    }

    public void SceneMAP()
    {
        GameController.LVL3Unlocked = true;
        SceneManager.LoadScene("Map");
    }
}
