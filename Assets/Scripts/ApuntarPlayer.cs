using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApuntarPlayer : MonoBehaviour
{
    public Transform apuntadorTR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentEulerAngles = transform.eulerAngles;
        transform.LookAt(apuntadorTR);
        transform.eulerAngles = new Vector3(currentEulerAngles.x, transform.eulerAngles.y, currentEulerAngles.z);
    }
}
