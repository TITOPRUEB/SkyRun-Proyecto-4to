using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObsEnX : MonoBehaviour
{
    public float xSpeed;
    public bool toRight;
    public float xRightLimit;
    public float xLeftLimit;

    int yOffset;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        toRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (toRight)
        {
            transform.position += new Vector3(xSpeed, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(xSpeed, 0, 0);
        }
        if(transform.position.z >= xRightLimit)
        {
            toRight = false;
        }
        else if(transform.position.z <= xLeftLimit)
        {
            toRight = true;
        }
    }
}
