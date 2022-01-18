﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue;

    Queue<string> sentences;

    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;

    string activeSentence;
    public float typingSpeed;

    AudioSource myAudio;
    public AudioClip speakSound;


    void Start()
    {

        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();


    }

    void StartDialogue()
    {
        sentences.Clear();
        // mete las frases puestas en sentences para luego mostrarlas
        foreach(string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentences();


    }

    // metodo para mostrar las frases ya cargadas
    void DisplayNextSentences()
    {
        if(sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            return;
        }

        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TypeTheSentences(activeSentence));
    }

    IEnumerator TypeTheSentences(string sentence)
    {
        displayText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
          //  myAudio.PlayOneShot(speakSound);
            yield return new WaitForSeconds(typingSpeed);
        }

       
    }

    private  void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            dialoguePanel.SetActive(true);
            StartDialogue();        
        }
    }


    private void OnTriggerStay2D(Collider2D col2)
    {
        if (col2.CompareTag("Player"))
        {
            if ((Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0) ) && displayText.text == activeSentence)
            {
                DisplayNextSentences();
            }
        }

    }

    private void OnTriggerExit2D(Collider2D col3)
    {
        if (col3.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);
            StopAllCoroutines();
        }

        
    }

}
