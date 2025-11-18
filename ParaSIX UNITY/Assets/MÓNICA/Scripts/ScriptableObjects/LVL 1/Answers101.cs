using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Answer", menuName = "Answer/Type")]

public class Answers101 : ScriptableObject
{
    public string[] answerInfected = new string[3];
    public string[] answerCivil = new string[3];
    public string[] answerNeutral = new string[3];
}
