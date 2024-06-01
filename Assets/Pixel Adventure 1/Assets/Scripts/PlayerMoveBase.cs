using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMoveBase : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 3f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    protected Rigidbody2D rb2D;
    private int verticalMovement = 0;
    private bool wasGrounded;
    private CheckGround checkGround;

    protected abstract KeyCode LeftKey { get; }
    protected abstract KeyCode RightKey { get; }
    protected abstract KeyCode JumpKey { get; }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        checkGround = GetComponentInChildren<CheckGround>();
        wasGrounded = checkGround.isGrounded;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        ApplyBetterJump();
    }

    private void HandleMovement()
    {
        bool isMoving = false;

        if (Input.GetKey(RightKey))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
            isMoving = true;
        }
        else if (Input.GetKey(LeftKey))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
            isMoving = true;
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }

        if (isMoving)
        {
            animator.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(JumpKey) && checkGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            checkGround.isGrounded = false;
        }
    }

    private void ApplyBetterJump()
    {
        if (betterJump)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
            }
            else if (rb2D.velocity.y > 0 && !Input.GetKey(JumpKey))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
            }
        }
    }

    private void UpdateAnimator()
    {
        if (rb2D.velocity.y > 0)
        {
            verticalMovement = 1;
        }
        else if (rb2D.velocity.y < 0)
        {
            verticalMovement = -1;
        }
        else
        {
            verticalMovement = 0;
        }

        animator.SetInteger("VerticalMovement", verticalMovement);

        if (checkGround.isGrounded != wasGrounded)
        {
            animator.SetBool("IsGrounded", checkGround.isGrounded);
            wasGrounded = checkGround.isGrounded;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            checkGround.isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            checkGround.isGrounded = false;
        }
    }
}
