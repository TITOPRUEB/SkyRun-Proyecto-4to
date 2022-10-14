using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool inWindZone = false;
    public GameObject windZone;

    private float currentMovementSpeed;
    public float movementSpeed;

    public bool isGrounded;

    public float gravity = 20.0f;
    private float currentGravity;
    public float friction = 1f;
    private float currentFriction;
    

    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;
    public float jumpForce;


    [SerializeField] private LayerMask FloorMask;
    [SerializeField] private Transform FeetTransform;
    [SerializeField] private Transform PlayerCamera;
    private Rigidbody RB;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensativity;


    private bool canMove = true; //If player is not hitted
    private bool isStuned = false;
    private bool wasStuned = false; //If player was stunned before get stunned another time
    private float pushForce;
    private Vector3 pushDir;
    private bool slide = false;

    public bool ShowCursor = false;

    public bool hasStarted = false;

    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        currentMovementSpeed = movementSpeed;
        currentGravity = gravity;
        currentFriction = friction;
        isGrounded = true;

        if (ShowCursor == false)
        {
            Cursor.visible = false;
        }


        RB = GetComponent<Rigidbody>();
    
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        MovePlayer();
        MovePlayerCamera();
    }

    private void FixedUpdate()
    {
        if (inWindZone)
        {
            RB.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }
    }

        void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "SpeedBoost")
        {
            Debug.Log("Estan en speedboost");
            movementSpeed = 50f;
            Speed = 50f;
            gravity = currentGravity;
            friction = currentFriction;
        }
        if (collision.gameObject.tag == "Wind")
        {
            windZone = collision.gameObject;
            inWindZone = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "SpeedBoost")
        {
            movementSpeed = 8f;
            Speed = 8f;
            gravity = currentGravity;
            friction = currentFriction;
        }
        if (collision.gameObject.tag == "Wind")
        {
            inWindZone = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == "Cinta")
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == "MetaFinal")
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == "Obstacle")
        {
            transform.position = new Vector3(1, 0.9f, -90);
        }
    }

    private void MovePlayer()
    {
        if (!hasStarted)
            return;
        if (!isGrounded)
            return;
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        RB.velocity = new Vector3(MoveVector.x, RB.velocity.y, MoveVector.z);
    }

    private void MovePlayerCamera()
    {
        xRot -= PlayerMouseInput.y * Sensativity;

        transform.Rotate(0f, PlayerMouseInput.x * Sensativity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    public void HitPlayer(Vector3 velocityF, float time)
    {
        RB.velocity = velocityF;

        pushForce = velocityF.magnitude;
        pushDir = Vector3.Normalize(velocityF);
        StartCoroutine(Decrease(velocityF.magnitude, time));
    }

    private IEnumerator Decrease(float value, float duration)
    {
        if (isStuned)
        {
            wasStuned = true;
            isStuned = true;
            canMove = false;

        }
         

        float delta = 0;
        delta = value / duration;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            yield return null;
            if (!slide) //Reduce the force if the ground isnt slide
            {
                pushForce = pushForce - Time.deltaTime * delta;
                pushForce = pushForce < 0 ? 0 : pushForce;
                //Debug.Log(pushForce);
            }
            RB.AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0)); //Add gravity
        }

        if (wasStuned)
        {
            wasStuned = false;
        }
        else
        {
            isStuned = false;
            canMove = true;
        }
    }
}
