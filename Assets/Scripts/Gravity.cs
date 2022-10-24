using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float mass;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Gravity")
        {
            rb.mass = mass;
        }
    
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.name == "Gravity")
        {
            rb.mass = 1;
        }
    }
}
