using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Cañon;
    public GameObject Cañon1;
    public GameObject Cañon2;
    public GameObject Cañon3;
    public GameObject Cañon4;
    public GameObject Cañon5;
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
        Cañon3.SetActive(true);
        Cañon4.SetActive(true);
        Cañon5.SetActive(true);

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
        Cañon3.SetActive(false);
        Cañon4.SetActive(false);
        Cañon5.SetActive(false);
    }
}