using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public float startTime = 60f;   // Tiempo inicial (para cuenta regresiva)
    public bool countdown = true;   // true = cuenta atrás, false = cronómetro normal
    public TMP_Text timerText;          // Texto UI donde mostrar el tiempo

    private float currentTime;
    private bool isRunning = true;

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        if (!isRunning) return;

        // Cuenta atrás
        if (countdown)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false;
                OnTimerEnd();
            }
        }
        else // Cronómetro ascendente
        {
            currentTime += Time.deltaTime;
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void OnTimerEnd()
    {
        Debug.Log("¡El tiempo se ha agotado!");
        // Aquí puedes llamar a un Game Over, bloquear clicks, etc.
    }

    public void StopTimer() => isRunning = false;
    public void StartTimer() => isRunning = true;
}


