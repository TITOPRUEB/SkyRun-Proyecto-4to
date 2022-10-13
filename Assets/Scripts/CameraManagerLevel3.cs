using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerLevel3 : MonoBehaviour
{

    public GameObject CountDown;
    public GameObject Time;
    public GameObject camIntro;
    public GameObject camPlayer;

    // Start is called before the first frame update
    void Start()
    {
        camPlayer.SetActive(false);
        camIntro.SetActive(true);
        CountDown.SetActive(false);
        Time.SetActive(false);
    }

    // Update is called once per frame
    public void CameraActivation()
    {
        camPlayer.SetActive(true);
        camIntro.SetActive(false);
        CountDown.SetActive(true);
        Time.SetActive(true);

    }
}
