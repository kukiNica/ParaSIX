using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRandomizer : MonoBehaviour
{
    public CharacterController[] person;

    public static int numRndm;

    void Start()
    {
        numRndm = Random.Range(1,4);
        Debug.Log(numRndm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
