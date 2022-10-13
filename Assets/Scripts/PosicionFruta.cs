using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionFruta : MonoBehaviour
{
    public Transform apuntadorTr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion lookRotation = Quaternion.LookRotation(apuntadorTr.position - transform.position);
        transform.rotation = lookRotation;
    }
}
