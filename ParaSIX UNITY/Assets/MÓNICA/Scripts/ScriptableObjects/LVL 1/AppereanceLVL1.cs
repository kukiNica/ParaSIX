using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum type
{
    infected, civilian
}

[CreateAssetMenu(fileName = "New Patient", menuName = "Patient")]

public class AppereanceLVL1 : ScriptableObject
{
    public string namePatient;

    public type type;

    [Space]

    public Sprite face;
    public Sprite leftHand;
    public Sprite rightHand;
    public Sprite leftFoot;
    public Sprite rightFoot;
    [Space]

    public Sprite patientBG;
}
