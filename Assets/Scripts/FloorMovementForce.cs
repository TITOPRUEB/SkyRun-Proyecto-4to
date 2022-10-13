using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovementForce : MonoBehaviour
{

    Rigidbody rb;
    public float force;
    
    void OnCollisionStay(Collision coll)
    {
        var PL = coll.gameObject.GetComponent<PlayerMovement>();
        if (PL)
        {
            rb = PL.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * force, ForceMode.Force);
        }
    }
    void OnCollisionExit(Collision coll)
    {
        var PL = coll.gameObject.GetComponent<PlayerMovement>();
        if (PL)
        {
            rb = null;
        }
    }
}
