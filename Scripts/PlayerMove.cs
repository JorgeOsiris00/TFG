 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private GameObject objectSoundJump;
    private AudioSource jumpSound;

    Rigidbody2D rb2D;

    public float runSpeed = 2;
    public float jumpSpeed = 3;
   // public float doubleJumpSpeed = 2.5f;
   // private bool canDoubleJump;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    // variables para wallSlide y wallJump
    bool isTouchingFront = false;
    bool wallSliding;
    public float wallSlidingSpeed = 0.75f;
    bool isTouchingDerecha;
    bool isTouchingIzquierda;





    //variables para mejorarCalidad del salto
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplayer = 1f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        jumpSound = objectSoundJump.GetComponent<AudioSource>();

    }

   
    void FixedUpdate()
    {
        // si se en cuentra en un dialogo con opciones, se quita el control hasta que termine
        if (DialogueManagerInk.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        else {  }


        // movimiento izq y derecha
        if (Input.GetKey("d") || Input.GetKey("right") && !isTouchingDerecha)
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            //activas la variable Run para que cambia de animacion a Run
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left") && !isTouchingIzquierda)
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            //que gire el sprite
            spriteRenderer.flipX = true;
            //activas la variable Run para que cambia de animacion a Run
            animator.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }

       
        // hacer el salto y doble salto
        if (Input.GetKey("space") )
        {
           

            if (CheckGround.isGrounded)
            {
               // canDoubleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                if (Input.GetKey("space")) jumpSound.Play();
            }
            else
            {
                if (Input.GetKeyDown("space") )
                {
                   /*
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump",true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                    */
                }
            }
            
        }

        // cuando estemos en el aire, cambiamos variables para animacion salto
        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        // cuando esta en el suelo, cambiamos variables para animacion correr
        if (CheckGround.isGrounded == true)
        {

            animator.SetBool("Jump", false);
           // animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }
        // comprobacion de que se esta callendo para la animacion de caer
        if (rb2D.velocity.y < 0)
        {
            animator.SetBool("Falling",true);
        }
         else if (rb2D.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }



        //activar/programar la mejoraCalidad de salto
        if (betterJump)
        {
            if (rb2D.velocity.y <0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
                // velocidad del salto += subir * la gravedad * el multiplicador nuestro * (ayuda a que 
                //                          no haya incocsistencia en los frames/segundo)
            }
            if (rb2D.velocity.y >0 && !Input.GetKey("space") )
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer) * Time.deltaTime;
            }
        }

        // comprobaciones wallSlide y wallJump
        if(isTouchingFront && ! CheckGround.isGrounded)
        {
            wallSliding = true;
        }else {wallSliding = false; }

        if (wallSliding)
        {
            animator.Play("wallSlide");
            rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Clamp(rb2D.velocity.y, - wallSlidingSpeed , float.MaxValue));
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ParedDerecha"))
        {
            isTouchingFront = true;
            isTouchingDerecha = true;

        }
        if (collision.gameObject.CompareTag("ParedIzquierda"))
        {
            isTouchingFront = true;
            isTouchingIzquierda = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingFront = false;
        isTouchingDerecha = false;
        isTouchingIzquierda = false;
    }



}
