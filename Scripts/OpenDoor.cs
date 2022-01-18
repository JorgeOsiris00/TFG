using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Text text;
    public string levelName; // tendras que poner fuera el Level que quieras (consulta Builds Settings )
                             // para los niveles
    private bool inDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // comprobamos si estamos en una puerta
        if (collision.gameObject.CompareTag("Player") )
        {
            text.gameObject.SetActive(true);
            inDoor = true;
        }




    }



    private void OnTriggerExit2D( Collider2D collision)
    {
        // estamos fuera de alguna puerta
        text.gameObject.SetActive(false);
        inDoor = false;




    }

    private void Update()
    {
        // si esta en la puerta y pulsa e , carga la escena
        if (inDoor && Input.GetKey("e") ) 
        {
            SceneManager.LoadScene(levelName);
        }


    }



}
