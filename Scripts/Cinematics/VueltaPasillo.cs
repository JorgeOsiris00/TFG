using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class VueltaPasillo : MonoBehaviour
{
    private PlayableDirector director;
    public GameObject controlPanel;
    public GameObject gameFinish;

    // Update is called once per frame
    void Awake()
    {
        director = GetComponent<PlayableDirector>();
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            director.Play();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            gameFinish.SetActive(true);

        }
    }

}
