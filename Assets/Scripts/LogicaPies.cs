using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public float mass;
    public Rigidbody rb;
    public PlayerMovement movimientoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        movimientoPlayer.hasJump = true;
        if (other.gameObject.name == "Gravity")
        {
            rb.mass = mass;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        movimientoPlayer.hasJump = false;

        if (other.gameObject.name == "Gravity")
        {
            rb.mass = 1;

        }
    }
}
