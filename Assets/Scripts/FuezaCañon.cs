using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuezaCañon : MonoBehaviour
{
    [SerializeField] GameObject[] FrutasInicio;
    public float FrutaVelocidadCanon2;
    int random = 0;
    public GameObject Frutas;

    public Transform apuntadorTR;
    Rigidbody rbBala;

    float cooldown;




    // Start is called before the first frame update
    void Start()
    {
        FrutasInicio = GameObject.FindGameObjectsWithTag("Frutas");


    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown > 1)
        {
            DispararFrutaAlAzar();
            cooldown = 0;
        }
    }

    void DispararFrutaAlAzar()
    {
        random = Random.Range(0, FrutasInicio.Length);
        //Debug.Log(FrutasInicio[random]);

        Frutas = FrutasInicio[random];

        GameObject clon;
        clon = Instantiate(Frutas);
        rbBala = clon.GetComponent<Rigidbody>();
        clon.transform.rotation = apuntadorTR.rotation;
        clon.transform.position = apuntadorTR.position;
        rbBala.AddForce(clon.transform.forward * FrutaVelocidadCanon2, ForceMode.Impulse);
        Destroy(clon, 40);
    }

}
