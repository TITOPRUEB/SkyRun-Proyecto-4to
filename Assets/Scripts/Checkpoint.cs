using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Deathwall1")
        {
            transform.position = new Vector3(287.24f, 0.174f, 0.027f);
            transform.eulerAngles = new Vector3(0, -90, 0);
        }

        if (col.gameObject.name == "Deathwall2")
        {
            transform.position = new Vector3(248.012f, -2.34f, -0.53f);
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        if (col.gameObject.name == "Deathwall3")
        {
            transform.position = new Vector3(42.6f, -6.1f, 0f);
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
    }
}

