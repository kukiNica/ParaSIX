using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Appereance
{
    HandLEFT, HandRIGHT, FootLeft, FootRight
}

public class AppereanceLVL1 : ScriptableObject
{
    public Appereance appereance;

    public Sprite frontDetail;
    public Sprite front;
    public Sprite face;
    public Sprite leftHand;
    public Sprite rightHand;
    public Sprite leftFoot;
    public Sprite rightFoot;
}
