using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool LVL1Unlocked, LVL2Unlocked, LVL3Unlocked;

    private void Start()
    {
        LVL1Unlocked = true;
        LVL2Unlocked = false;
        LVL3Unlocked = false;
    }

    public void UnlockLVL2()
    {
        LVL2Unlocked = true;
    }

    public void UnlockLVL3()
    {
        LVL3Unlocked = true;
    }
}
