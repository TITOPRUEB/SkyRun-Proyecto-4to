using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerText : MonoBehaviour
{
    public Text gameTimerText;
    public static float gameTimer = 0f;
    
    

    public bool Started = false;

    public void Start()
    {
        gameTimerText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Started)
        {
            gameTimer += Time.deltaTime;

            int segundos = (int)(gameTimer % 60);
            int minutos = (int)(gameTimer / 60) % 60;
            int horas = (int)(gameTimer / 3600) % 24;

            string timerString = string.Format("{0:0}:{1:00}:{2:00}", horas, minutos, segundos);

            gameTimerText.text = timerString;
        }
    }
}
