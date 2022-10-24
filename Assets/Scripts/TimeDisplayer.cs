using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayer : MonoBehaviour
{
    Text display;
    GameTimerText GMTXT2;
    
    void Start()
    {
        display = GetComponent<Text>();
        GMTXT2 = FindObjectOfType<GameTimerText>();
        if(GMTXT2)
            display.text = "Tu tiempo fue de: " + GMTXT2.gameTimer+ " segundos";
    }
}
