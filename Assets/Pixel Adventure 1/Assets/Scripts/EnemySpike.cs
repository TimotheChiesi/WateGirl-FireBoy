using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            //Destroy(collision.gameObject);
            GameOverScreen.setUp();
        }
    }
}
