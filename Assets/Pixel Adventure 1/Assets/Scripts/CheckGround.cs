using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool isGrounded;
    private int groundColliders = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            groundColliders++;
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            groundColliders--;
            if (groundColliders <= 0)
            {
                isGrounded = false;
                groundColliders = 0; // Asegúrate de que no sea negativo
            }
        }
    }
}
