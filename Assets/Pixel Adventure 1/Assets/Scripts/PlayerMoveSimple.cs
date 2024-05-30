using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSimple : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    private Rigidbody2D rb2D;
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 3f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private int verticalMovement = 0;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle horizontal movement
        if (Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }

        // Handle jump
        if (Input.GetKeyDown("up") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        // Better jump
        if (betterJump)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

        // Update vertical movement for animator
        if (rb2D.velocity.y > 0)
        {
            verticalMovement = 1; // Going up
        }
        else if (rb2D.velocity.y < 0)
        {
            verticalMovement = -1; // Going down
        }
        else
        {
            verticalMovement = 0; // Idle or running
        }

        animator.SetInteger("VerticalMovement", verticalMovement);
        animator.SetBool("IsGrounded", CheckGround.isGrounded);
    }
}
