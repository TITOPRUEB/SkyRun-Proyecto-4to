using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    [Range(100, 10000)]
    public float bouncehight;


    void OnCollisionEnter(Collision col)
    {
        GameObject bouncer = col.gameObject;
        Rigidbody rb = bouncer.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * bouncehight);
    }
}
