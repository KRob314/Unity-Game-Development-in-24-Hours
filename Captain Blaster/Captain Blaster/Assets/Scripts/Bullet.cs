using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    GameManager gameManager; // Note this is private this time

    void Start()
    {
        // Because the bullet doesn't exist until the game is running
        // we must find the Game Manager a different way.
        gameManager = GameObject.FindObjectOfType<GameManager>();
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0f, speed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject); // Destroy the meteor
        gameManager.AddScore(); // Increment the score
        Destroy(gameObject); // Destroy the bullet
    }
}
