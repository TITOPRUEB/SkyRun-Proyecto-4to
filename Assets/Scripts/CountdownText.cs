using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownText : MonoBehaviour
{
    public Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
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
        FindObjectOfType<GameTimerText>().Started = true;
        //FindObjectOfType<PlayerMov3Level>().hasStarted = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
