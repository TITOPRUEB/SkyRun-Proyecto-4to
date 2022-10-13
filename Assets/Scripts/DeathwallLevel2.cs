using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathwallLevel2 : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Deathwall")
        {
            transform.position = new Vector3(-0.92f, 3.03f, -64.2f);
        }

        if (col.gameObject.tag == "Frutas")
        {
            rb.AddForce(0, 150, 0);
        }
    }
}
