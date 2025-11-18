using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum State
{
    Infected, Civilian, Neutral
}

public enum Personality
{
    Calm, Aggressive
}

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]

public class CharactersInfo : ScriptableObject
{
    public string charName;
    public Sprite charAppereance;
    public int charAge;
    public Personality charPersonality;
    public State charType;
    public State neutral = State.Neutral;

    public void IfInfected()
    {

    }
}
