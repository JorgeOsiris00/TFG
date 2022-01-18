using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    
    private PlatformEffector2D effector;
    private float waitedTime;
    public float startwaitTime;

    void Start()
    {
        // coje la referencia del platformEffector2D
        effector = GetComponent<PlatformEffector2D>();

    }

   
    void Update()
    {
        // volvemos a poner la espera de bajar a 0 
        //( esta espera hace mas comoda la bajada al jugador)
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s"))
        {
            waitedTime = startwaitTime;
        }


        // cuando pulsemos abajop o s , bajamos de la plataforma tras un tiempo
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s") )
        {
            if (waitedTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitedTime = startwaitTime;
            }
            else
            {
                waitedTime -= Time.deltaTime;
            }
        }
        // comprobar que cuando le demos a la tecla de salto, se resete la rotacion
        // para poder volver a subir
        if (Input.GetKey("space"))
        {
            effector.rotationalOffset = 0;
        }


    }
}
