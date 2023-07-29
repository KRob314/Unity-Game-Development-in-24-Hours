using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject bulletPrefab;
    public float speed = 10f;
    public float xLimit = 7f;
    public float reloadTime = 0.5f;
    float elapsedTime = 0f;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        float xInput = Input.GetAxis("Horizontal");
        transform.Translate(xInput * speed * Time.deltaTime, 0f, 0f);

        // Clamp the ship's x position
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        transform.position = position;

        // Spacebar fires. The default InputManager settings call this "Jump"
        // Only happens if enough time has elapsed since last firing.
        if (Input.GetButtonDown("Jump") && elapsedTime > reloadTime)
        {
            // Instantiate the bullet 1.2 units in front of the player
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0, 1.2f, 0);
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

            elapsedTime = 0f; // Reset bullet firing timer
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.PlayerDied();
    }
}
