using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // se hara pensando que el Player tiene 1 vida
        if (collision.transform.CompareTag("Player"))
        {
            //Debug.Log("Player Damaged"); sirven como marcadores en la consola
            // destruye el objeto que colisione
            // Destroy(collision.gameObject);
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }


    }








}
