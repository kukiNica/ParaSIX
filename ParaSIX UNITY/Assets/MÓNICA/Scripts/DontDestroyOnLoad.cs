using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        if (this.gameObject == null)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
