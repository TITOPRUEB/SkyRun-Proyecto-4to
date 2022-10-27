using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayer1 : MonoBehaviour
{
    Text display;  

    void Start()
    {
        display = GetComponent<Text>();
       
        display.text = "Tu tiempo fue de: " + GameTimerText.gameTimer + " segundos";            
    }
}
