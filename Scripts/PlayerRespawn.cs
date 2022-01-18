using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private GameObject hitSoundObject;
    private AudioSource hitsound;
    private float checkPointPositionX , chechPointPositionY;
    public Animator animator;

    


    void Start()
    {
        hitsound = hitSoundObject.GetComponent<AudioSource>();
        // comprueba si sea tocado un checkpoint
        if (PlayerPrefs.GetFloat("checkPointPositionX") !=0 )
        {

            // mandamos al PJ al checkPoint
            transform.position= (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));

        }
    }

    
    //guarda informacion para cuando pasemos por un checkpoint
    public void reachedCheckPoint(float x, float y)
    {
        hitsound = hitSoundObject.GetComponent<AudioSource>();
        PlayerPrefs.SetFloat("checkPointPositionX",x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);




    }

    // cuando dañen al PJ
    public void PlayerDamaged()
    {
       
        hitsound.Play();
        animator.Play("Hit");
        // resetear el nivel 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    // tendras que hacer uno similar con PlayerDie para hacer la animacion
    // cuando se ha llamado en el momento del disparo


}
