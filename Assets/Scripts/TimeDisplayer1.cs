using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayer1 : MonoBehaviour
{
    Text display;
    GameTimerText GMTXT1;
    juegos juegosScript;

    void Start()
    {
        display = GetComponent<Text>();
        GMTXT1 = FindObjectOfType<GameTimerText>();
        juegosScript = FindObjectOfType<juegos>();
        if (GMTXT1)
        {
            display.text = "Tu tiempo fue de: " + GameTimerText.gameTimer + " segundos";
            juegosScript.puntajeactual = GameTimerText.gameTimer;
            juegosScript.CallSaveData();
        }
    }
}
