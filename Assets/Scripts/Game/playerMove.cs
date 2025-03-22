using UnityEngine;
using System;
using System.Collections;

public class playMove : MonoBehaviour
{
    float moveSpeed = 5f;
    float jumpForce = 6f;
    float horizontalInput;
    bool isFacingRight = false;
    bool isGrounded = false;

    Rigidbody2D rb;
    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            anim.SetBool("isJumping", !isGrounded);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        anim.SetFloat("xVelocity", Math.Abs(rb.linearVelocity.x));
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    void FlipSprite()
    {
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;

            // Asegurar que no se oculta el sprite
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * (isFacingRight ? 1 : -1),
                                            transform.localScale.y,
                                            transform.localScale.z);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        anim.SetBool("isJumping", !isGrounded);
    }
}
