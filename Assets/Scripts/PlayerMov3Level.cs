using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov3Level : MonoBehaviour
{
    public bool inWindZone = false;
    public GameObject windZone;
    public float movementSpeed;

    public bool isGrounded;

    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;
    public float jumpForce;
    
    [SerializeField] private Transform FeetTransform;
    [SerializeField] private Transform PlayerCamera;
    private Rigidbody RB;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensativity;

    private float pushForce;
    private Vector3 pushDir;

    public bool ShowCursor = false;

    public bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;

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
        if (collision.gameObject.tag == "Wind")
        {
            windZone = collision.gameObject;
            inWindZone = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
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
        if (col.gameObject.tag == "MetaFinal")
        {
            isGrounded = true;
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

    }
}
