using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownText : MonoBehaviour
{
    public Text countdownText;

    void Start()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        GameTimerText Gtt = FindObjectOfType<GameTimerText>();
        Gtt.gameTimerText.gameObject.SetActive(false);
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
        FindObjectOfType<PlayerMovement>().hasStarted = true;
        Gtt.Started = true;
        Gtt.ResetTime();
        Gtt.gameTimerText.gameObject.SetActive(true);
    }

}
