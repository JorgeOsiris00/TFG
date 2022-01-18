using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>().reachedCheckPoint(transform.position.x , transform.position.y);

            //activar animacion de sacar la bandera
            GetComponent<Animator>().enabled = true;
        }


    }




}
