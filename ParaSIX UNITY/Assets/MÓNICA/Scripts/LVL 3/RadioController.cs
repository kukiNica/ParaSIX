using UnityEngine;
using UnityEngine.UI;

public class RadioController : MonoBehaviour
{
    [Header("Interfaces")]
    public GameObject game;
    public GameObject radio;
    [Space]

    [Header("Radio Buttons (Controller)")]
    public Button buttonONOFF;
    public Button buttonDEFAULT;
    public Button buttonMUSIC;
    public Button buttonNEWS;
    [Space]

    [Header("Music")]
    public AudioSource radioMusic;
    [Space]

    public AudioClip musicInterference;
    public AudioClip musicAmbience;
    public AudioClip musicNews;

    bool musicPlaying = true;

    void Start()
    {
        radioMusic.Play();
        musicDEFAULT();
    }

    public void musicONOFF()
    {
        musicPlaying = false;
        radioMusic.clip = null;
        radioMusic.Play();
    }

    public void musicDEFAULT()
    {
        musicPlaying = true;
        radioMusic.clip = musicInterference;
        radioMusic.Play();
    }

    public void musicNEWS()
    {
        musicPlaying = true;
        radioMusic.clip = musicNews;
        radioMusic.Play();
    }

    public void musicAMBIENCE()
    {
        musicPlaying = true;
        radioMusic.clip = musicAmbience;
        radioMusic.Play();
    }
}
