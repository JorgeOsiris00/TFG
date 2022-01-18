using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDown : MonoBehaviour
{

    [SerializeField] private float tiempoEspera;
    [SerializeField] private float tiempoReaparece;
    [SerializeField] private float margen;
    
    private Rigidbody2D rbody;

    private Vector3 posIni;
    private bool move = false;
    private float moveD = 0.02f;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        posIni = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position = new Vector3(transform.position.x + moveD , transform.position.y, transform.position.z);
            if(transform.position.x >= posIni.x + margen || transform.position.x <= posIni.x - margen)
            {
                moveD *= -1;
            }

        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Invoke("Cae", tiempoEspera);
            Invoke("Respawn", tiempoReaparece);
            move = true;


        }
    }

    private void Cae()
    {
        rbody.isKinematic = false;


    }

   private void Respawn()
    {
        move = false;
    }
}
