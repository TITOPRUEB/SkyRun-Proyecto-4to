using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptLevel2 : MonoBehaviour
{
    public CameraManager camManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateCamera()
    {
        camManager.CameraActivation();
    }
}
