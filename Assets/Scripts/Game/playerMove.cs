// Alberto Gallegos Hernández A01752303
// 22/03/2025

using UnityEngine;
using System;
using System.Collections;

// Clase que controla el movimiento del jugador
public class playMove : MonoBehaviour
{
    // Variables para controlar la velocidad de movimiento y salto
    float moveSpeed = 5f;
    float jumpForce = 6f;
    float horizontalInput;
    bool isFacingRight = false;
    bool isGrounded = false;

    Rigidbody2D rb;
    Animator anim;
    void Start()
    {
        // Se obtienen los componentes del jugador
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Se obtiene la entrada del jugador
        horizontalInput = Input.GetAxis("Horizontal");
        // Función para voltear el sprite del jugador
        FlipSprite();
        // Se verifica si el jugador presiona el botón de salto y si está en el suelo   
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            anim.SetBool("isJumping", !isGrounded);
        }
    }
    // Función para mover al jugador
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        anim.SetFloat("xVelocity", Math.Abs(rb.linearVelocity.x));
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }
    // Función para voltear el sprite del jugador
    void FlipSprite()
    {
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;

            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * (isFacingRight ? 1 : -1),
                                            transform.localScale.y,
                                            transform.localScale.z);
        }
    }

    // Función para detectar si el jugador está en el suelo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        anim.SetBool("isJumping", !isGrounded);
    }
}