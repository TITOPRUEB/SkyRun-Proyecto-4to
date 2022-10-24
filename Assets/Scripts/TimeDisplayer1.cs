using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayer1 : MonoBehaviour
{
    Text display;
    GameTimerText GMTXT1;

    void Start()
    {
        display = GetComponent<Text>();
        GMTXT1 = FindObjectOfType<GameTimerText>();
        if (GMTXT1)
            display.text = "Tu tiempo fue de: " + GMTXT1.gameTimer + " segundos";
    }
}
