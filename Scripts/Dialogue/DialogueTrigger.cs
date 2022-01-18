using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("exclamacion")]
    [SerializeField] private GameObject exclamacion;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;


    private void Awake()
    {
        playerInRange = false;
        exclamacion.SetActive(false);
    }

    private void Update()
    {



        if (playerInRange && !DialogueManagerInk.GetInstance().dialogueIsPlaying)
        {
            exclamacion.SetActive(true);
            if (Input.GetKeyDown("space") )
            {
                DialogueManagerInk.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            exclamacion.SetActive(false);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

}
