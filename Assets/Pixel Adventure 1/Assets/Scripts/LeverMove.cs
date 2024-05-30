using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 0.1f;
    public float currentRotationAngle;
    private bool isActivated = false;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        currentRotationAngle = transform.rotation.eulerAngles.z;
        Debug.Log(currentRotationAngle);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        // Refresh rotation angle on z axis
        currentRotationAngle = transform.rotation.eulerAngles.z;
        Debug.Log(currentRotationAngle);
        if (isActivated)
        {
            Debug.Log(Vector3.forward * currentRotationAngle - Vector3.forward * rotationSpeed);
            Debug.Log(currentRotationAngle);
            // Check if the z-value rotation is under the threshold
            if ((currentRotationAngle < 60f && currentRotationAngle > -60f) || Mathf.Floor(currentRotationAngle)==60f)
            {
                transform.Rotate(Vector3.forward * currentRotationAngle + Vector3.forward * rotationSpeed);
                
                Debug.Log("Value is under threshold");
            }
            // Rotate the lever on its z-axis
            //if (Mathf.Abs(transform.rotation.eulerAngles.z) < 45f && Mathf.Abs(transform.rotation.eulerAngles.z) > -45f)
            //{
            //    // Get the collision point in world space
            //    Vector2 collisionPoint = collision.GetContact(0).point;
            //    // Get the lever's position in world space
            //    Vector2 leverPosition = transform.position;
            //    // Get the direction from the lever to the collision point
            //    Vector2 direction = collisionPoint - leverPosition;
            //    // Get the angle between the direction and the lever's right direction
            //    float angle = Vector2.SignedAngle(Vector2.right, direction);

            //    // Rotate the lever based on collision side
            //    if (angle > 0) // Collision on the right side
            //        rb.MoveRotation(rb.rotation - 30f);
            //    else // Collision on the left side
            //        rb.MoveRotation(rb.rotation + 30f);
            //}
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActivated = true;
            Debug.Log("Collision true");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isActivated = false;
        Debug.Log("Collision false");
    }
}
