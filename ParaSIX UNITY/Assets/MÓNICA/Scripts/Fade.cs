using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image intro;

    void Start()
    {
        intro.gameObject.SetActive(true);
    }

    private void Update()
    {
        if(intro.color.a == 0)
        {
            intro.gameObject.SetActive(false);
        }
    }
}
