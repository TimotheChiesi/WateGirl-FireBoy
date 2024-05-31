using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeMove2 : MonoBehaviour
{
    private Rigidbody2D rb;

    public float uppositionY = 0.45f;
    public float downpositiony = -0.18f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    public void up()
    {
        Vector2 currentPosition = rb.position;

        // Modifiez uniquement la composante Y
        currentPosition.y = uppositionY;

        // Mettez à jour la position du Rigidbody2D
        rb.position = currentPosition;
    }
    public void down()
    {
        Vector2 currentPosition = rb.position;

        // Modifiez uniquement la composante Y
        currentPosition.y = downpositiony;

        // Mettez à jour la position du Rigidbody2D
        rb.position = currentPosition;
    }
}
