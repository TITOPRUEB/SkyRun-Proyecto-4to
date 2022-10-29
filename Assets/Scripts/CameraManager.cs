using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Cañon;
    public GameObject Cañon1;
    public GameObject Cañon2;
    public GameObject CountDown;
    public GameObject Time;
    public GameObject camIntro;
    public GameObject camPlayer;
    // Start is called before the first frame update
    void Start()
    {
        camPlayer.SetActive(false);
        camIntro.SetActive(true);
        Cañon.SetActive(false);
        Cañon1.SetActive(false);
        Cañon2.SetActive(false);
        CountDown.SetActive(false);
        Time.SetActive(false);
       

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CameraActivation()
    {
        camPlayer.SetActive(true);
        camIntro.SetActive(false);
        Cañon.SetActive(true);
        Cañon1.SetActive(true);
        Cañon2.SetActive(true);
        CountDown.SetActive(true);
        Time.SetActive(true);

    }
}