using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Pasillo : MonoBehaviour
{

   
    [SerializeField] private GameObject jugador2D;
    [SerializeField] private GameObject exclamacion;
    [SerializeField] private GameObject Trigger;
    //[SerializeField] private PlayableDirector director1;
    //[SerializeField] private PlayableDirector director2;
    [SerializeField] private GameObject director1;
    [SerializeField] private GameObject director2;
    [SerializeField] private GameObject Jugador3;

    void Awake()
    {
       // director1 = GetComponent<PlayableDirector>();
       // director2 = GetComponent<PlayableDirector>();

    }
  


    void Update()
    {
        // aqui cogemos la variable del Global.ink que se ha modificado segun la opcion del dialogo
        string option = ((Ink.Runtime.StringValue)DialogueManagerInk
            .GetInstance()
            .getVariablesState("option")).value;



        switch (option)
        {
            // se deja ir al herido
            case "opcion1":
                if (!DialogueManagerInk.GetInstance().dialogueIsPlaying)
                    exclamacion.SetActive(false);
                    Trigger.SetActive(false);
                director1.SetActive(true);
                   // director1.Play();
               
                break;
            
            // se dispara al herido
            case "opcion2":
                if (!DialogueManagerInk.GetInstance().dialogueIsPlaying)
                    exclamacion.SetActive(false);

                director2.SetActive(true);
                //Jugador3.SetActive(false);
                    //director2.Play();
                    //jugador2D.SetActive(true);




                break;

            default: break;


        }


    }
}

