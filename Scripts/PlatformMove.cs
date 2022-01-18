﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    public float speed = 0.5f;
    private  float waitTime;
    public Transform[] moveSpots;
    public float startWaitTime = 2;
    private int i = 0;


    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {

            if(waitTime <=0)
            {
                if(moveSpots[i] != moveSpots[moveSpots.Length -1])
                {
                    i++;
                }
                else { i = 0; }
                waitTime = startWaitTime;


            }
            else { waitTime -= Time.deltaTime; }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // cuando un objeto/jugador colisiona, se convierte en hijo de la plataforma
        // de esta forma el objeto/jugador se mueve con la plataforma
        collision.collider.transform.SetParent(transform);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // le quita la condicion de hijo para evitar errores cuando sale de la conexión
        collision.collider.transform.SetParent(null);
    }
    

}
