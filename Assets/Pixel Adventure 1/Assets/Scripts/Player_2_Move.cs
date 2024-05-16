using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_Move : MonoBehaviour
{

    public float runSpeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D rb2D;
    public bool betterJump = false;
    public float fallMultiplier = 0.5f; 
    public float lowJumpMultiplier = 3f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey("d")){
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a")){
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }

        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }

        if (Input.GetKey("w") && CheckGround.isGrounded){
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        if(CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if(CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
        }

        if (betterJump)
        {
            if(rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if(rb2D.velocity.y>0 && !Input.GetKey("w"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}