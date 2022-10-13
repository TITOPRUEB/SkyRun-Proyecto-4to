using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Deathwall1")
        {
            transform.position = new Vector3(264.6f, -6.6f, 100.4f);
            transform.eulerAngles = new Vector3(0, -90, 0);
        }

        if (col.gameObject.name == "Deathwall2")
        {
            transform.position = new Vector3(50.3f, -12.3f, 94.9f);
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        if (col.gameObject.name == "Deathwall3")
        {
            transform.position = new Vector3(42.6f, -6.1f, 0f);
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
    }
}

