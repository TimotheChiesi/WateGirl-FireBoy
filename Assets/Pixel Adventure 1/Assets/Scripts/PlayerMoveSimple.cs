using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSimple : MonoBehaviour
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
        if (Input.GetKey("d") || Input.GetKey("right") ){
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left") ){
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if (Input.GetKey("space") && CheckGround.isGrounded){
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
        if (betterJump){
            if(rb2D.velocity.y<0){
                rb2D.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if(rb2D.velocity.y>0 && !Input.GetKey("space")){
                rb2D.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }

    }
}