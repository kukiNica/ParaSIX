using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public GameObject general;
    public GameObject graphics;
    public GameObject controls;

    public Button buttonGeneral;
    public Button buttonGraphics;
    public Button buttonControls;

    public Button buttonClose;
    public Canvas canvaSettings;
    public Canvas canvaInterface;

    //GENERAL
    public TMP_Text textBrightness;
    public TMP_Text textMusic;

    public Image panelBrightness;
    public Image panelBrightnessJuego;
    public float brightnessValue;

    public AudioSource musicSource;
    public float musicValue;

    public Slider sliderBrightness;
    public Slider sliderMusic;

    //GRAPHICS
    public TMP_Text textMode;
    public TMP_Dropdown dropdownMode;

    public TMP_Text textResolution;
    public TMP_Dropdown dropdownResolution;
    Resolution[] resolutions;

    public TMP_Text textGraphics;

    void Start()
    {
        //Al abrir los ajustes
        OpenGENERAL();

        //BRILLO
        sliderBrightness.value = PlayerPrefs.GetFloat("Brightness", 0);
        panelBrightness.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, brightnessValue);
        panelBrightnessJuego.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, brightnessValue);

        //VOLUME
        sliderMusic.value = PlayerPrefs.GetFloat("Music", 0.25f);
        musicSource.volume = musicValue;

        //MODE - Full Screen

        //RESOLUTION
        CheckResolution();
    }

    public void OpenGENERAL()
    {
        general.SetActive(true);

        CloseGRAPHICS();
        CloseCONTROLS();
    }

    public void CloseGENERAL()
    {
        general.SetActive(false);
    }

    public void OpenGRAPHICS()
    {
        graphics.SetActive(true);

        CloseGENERAL();
        CloseCONTROLS();
    }

    public void CloseGRAPHICS()
    {
        graphics.SetActive(false);
    }

    public void OpenCONTROLS()
    {
        controls.SetActive(true);

        CloseGENERAL();
        CloseGRAPHICS();
    }

    public void CloseCONTROLS()
    {
        controls.SetActive(false);
    }

    //BRIGHTNESS
    public void ChangeBrightness(float value)
    {
        brightnessValue = value;
        PlayerPrefs.SetFloat("Brightness", brightnessValue);
        panelBrightness.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, brightnessValue);
        panelBrightnessJuego.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, brightnessValue);
    }

    //VOLUME
    public void ChangeVolume(float value)
    {
        musicValue = value;
        PlayerPrefs.SetFloat("Volume", musicValue);
        musicSource.volume = musicValue;
    }

    //MODE - Full Screen
    public void ActiveFullScreen(int value)
    {
        bool pantallaCompleta = true;

        if (value == 0)
        {
            pantallaCompleta = true;
        }
        else
        {
            pantallaCompleta = false;
        }

        Screen.fullScreen = pantallaCompleta;
    }

    //RESOLUTION
    public void CheckResolution()
    {
        resolutions = Screen.resolutions;
        dropdownResolution.ClearOptions();

        List<string> options = new List<string>();
        int actualResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string opt = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(opt);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                actualResolution = i;
            }
        }
        dropdownResolution.AddOptions(options);
        dropdownResolution.value = actualResolution;
        dropdownResolution.RefreshShownValue();
        dropdownResolution.value = PlayerPrefs.GetInt("ResolutionValue", 0);
    }
    public void ChangeResolution(int value)
    {
        PlayerPrefs.SetInt("ResolutionValue", dropdownResolution.value);
        Resolution resolution = resolutions[value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void CloseSettings()
    {
        canvaSettings.enabled = false;
        canvaInterface.enabled = true;
    }
}
