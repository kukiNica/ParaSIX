using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionsControllerLVL1 : MonoBehaviour
{
    int numRndm;
    State charState;

    [SerializeField] private TMP_Text answerText;
    [SerializeField] private Answers101 answer1;
    [SerializeField] private Answers101 answer2;
    [SerializeField] private Answers101 answer3;

    private void Start()
    {
        answerText.text = null;
        numRndm = Random.Range(0, 3);
        Debug.Log("num " + numRndm);
    }

    public void Question1()
    {
        answerText.text = answer1.answerInfected[numRndm];
        /*
        if (charState == State.Infected)
        {
            answerText.text = answer1.answerInfected[numRndm];
        }
        else if (charState == State.Civilian)
        {
             answerText.text = answer1.answerCivil[numRndm];
        }
        else if (charState == State.Neutral)
        {
            answerText.text = answer1.answerNeutral[numRndm];
        }*/
    }

    public void Question2() 
    {
        answerText.text = answer2.answerInfected[numRndm];
    }

    public void Question3() 
    {
        answerText.text = answer3.answerInfected[numRndm];
    }
}
