using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersController : MonoBehaviour
{
    public CharactersInfo[] characters;
    string character1Status;

    int numRndm;

    void Start()
    {
        numRndm = Random.Range(0,3);
        character1Status = characters[0].charType.ToString();
    }

    void Update()
    {
        
    }
}
