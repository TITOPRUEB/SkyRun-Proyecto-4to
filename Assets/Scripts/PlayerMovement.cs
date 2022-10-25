using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool inWindZone = false;
    public GameObject windZone;

    private float currentMovementSpeed;
    public float movementSpeed;
    private float rotateSpeed;

    public bool isGrounded;

    public float gravity = 20.0f;
    private float currentGravity;
    public float friction = 1f;
    private float currentFriction;
    

    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;
    public float jumpForce;
    public bool hasJump;


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
    private Vector3 moveDir;

    public float x, y = 5;

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
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();

        if (hasJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Anim.SetBool("Salte", true);
                RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            Anim.SetBool("tocoSuelo", true);
        }
        else
        {
            estoyCayendo();
        }

         x = Input.GetAxis("Horizontal");
         y = Input.GetAxis("Vertical");

         Anim.SetFloat("VelX", x);
         Anim.SetFloat("VelY", y);
    }

    private void FixedUpdate()
    {
        if (inWindZone)
        {
            RB.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }

        transform.Rotate(0, x * Time.deltaTime * rotateSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * movementSpeed);
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
        //if (col.gameObject.tag == "Martillo")
        //{

        //}

    }

    private void MovePlayer()
    {
        if (!hasStarted)
            return;
        if (!isGrounded)
            return;
 
        Vector3 transformPosition = new Vector3(x * movementSpeed * Time.deltaTime, 0, y * movementSpeed * Time.deltaTime);
        transform.position += transformPosition;

        

        Vector3 direction = Vector3.forward * y + Vector3.right * x;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
     
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

    public void estoyCayendo()
    {
        Anim.SetBool("Salte", false);
        Anim.SetBool("tocoSuelo", false);
    }
}
