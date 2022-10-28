using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private PlayerMovement controller;

    private float verticalVelocity;
    private float gravity = 14.0f;
    private float jumpForce = 10.0f;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)

        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }

            Vector3 moveVector = Vector3.zero;
            moveVector.x = Input.GetAxis("Horizontal") * 5;
            moveVector.y = verticalVelocity;
            moveVector.z = Input.GetAxis("Vertical") * 5;
            //controller.(moveVector * Time.deltaTime);

        }


    }
}
