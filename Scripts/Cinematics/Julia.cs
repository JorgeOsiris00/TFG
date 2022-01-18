using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class Julia : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private GameObject juliaH;
    [SerializeField] private GameObject juliaD;
    [SerializeField] private GameObject Trigger;


    // Update is called once per frame
    void Update()
    {
        // aqui cogemos la variable del Global.ink que se ha modificado segun la opcion del dialogo
        string option = ((Ink.Runtime.StringValue)DialogueManagerInk
            .GetInstance()
            .getVariablesState("option")).value;

        

        switch (option)
        {
            // ayudarla a morir
            case "opcion1":
                if(!DialogueManagerInk.GetInstance().dialogueIsPlaying)
                animator.SetBool("muerte", true);
                juliaH.SetActive(false);
                juliaD.SetActive(true);
                break;

            // dejarla a su suerte
            case "opcion2":
                Trigger.SetActive(false);
                break;

            default: break;            
    

        }


    }
}
