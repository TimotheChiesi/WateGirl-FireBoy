using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 initialPosition;
    
    public float movementDifference = 0.1f; // Parámetro para la diferencia de movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        initialPosition = rb.position; // Guardar la posición inicial
    }

    public void up()
    {
        Vector2 currentPosition = rb.position;

        // Ajustar la posición Y sumando la diferencia de movimiento
        currentPosition.y = initialPosition.y + movementDifference;

        // Actualizar la posición del Rigidbody2D
        rb.position = currentPosition;
    }

    public void down()
    {
        // Volver a la posición inicial
        rb.position = initialPosition;
    }
}
